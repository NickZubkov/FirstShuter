using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int _hp = 3;
    [Space]
    [SerializeField] private AudioClip[] _audioClips = null;
    [Space]
    [SerializeField] private ParticleSystem _blood = null;

    private bool _isAlive = true;
    private bool _playerInRange = false;
    private NavMeshAgent navMeshAgent = null;
    private int _CurrentWaypointIndex = 0;
    private GameObject _target = null;
    private Animator _animator = null;
    private Transform[] _way = null;
    private AudioSource _enemyAudio = null;


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _enemyAudio = GetComponent<AudioSource>();
    }
    private void Start()
    {
        _target = GameObject.Find("Player");
        navMeshAgent.SetDestination(_way[0].position);
    }
    private void Update()
    {
        if (_playerInRange && _isAlive)
        {
            navMeshAgent.SetDestination(_target.transform.position);
            _animator.SetBool("AttackStart", true);
            _animator.SetBool("AttackEnd", false);
            if (_enemyAudio.clip == _audioClips[1])
            {
                _enemyAudio.Stop();
                _enemyAudio.clip = _audioClips[0];
            }
            if (!_enemyAudio.isPlaying)
            {
                _enemyAudio.Play();
            }
            Invoke("EnemyAttackAnimation", 1f);
        }
        else if (_isAlive && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            _CurrentWaypointIndex = (_CurrentWaypointIndex + 1) % _way.Length;
            navMeshAgent.SetDestination(_way[_CurrentWaypointIndex].position);
            _animator.SetBool("AttackEnd", true);
            _animator.SetBool("AttackStart", false);
            _animator.SetBool("Attack", false);
            _enemyAudio.clip = _audioClips[1];
            if (!_enemyAudio.isPlaying && !_playerInRange)
            {
                _enemyAudio.Play();
            }
        }
    }
    private void  OnTriggerEnter(Collider other)
    {
        PlayerInRangeCheck(other);
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerInRangeCheck(other);
    }
    private void PlayerInRangeCheck(Collider other)
    {
        if (other.CompareTag("Player"))
            _playerInRange = !_playerInRange;
    }
    public void TakeDamage(int damage)
    {
        _blood.Play();
        if (_isAlive)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                _isAlive = false;
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
                GetComponent<AudioSource>().enabled = false;
                _animator.applyRootMotion = false;
                _animator.SetBool("Death", true);
                gameObject.GetComponentInChildren<EnemyDamage>()._enemyDamage = 0;
                Invoke("Death", 0.1f);
            }
        }
    }
    public void Init(Transform[] way)
    {
        _way = way;
    }
    private void Death()
    {
        _animator.SetBool("Death", false);
        _target.GetComponent<IEnemyDamage>().Kills(1);
    }
    private void EnemyAttackAnimation()
    {
        _animator.SetBool("Attack", true);
    }
}
