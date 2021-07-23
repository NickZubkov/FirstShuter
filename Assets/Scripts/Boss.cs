using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Boss : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int _hp = 12;
    [SerializeField] private GameObject _target = null;
    [SerializeField] private ParticleSystem _blood = null;


    private bool _isAlive = true;
    private NavMeshAgent navMeshAgent = null;

    private Animator _animator = null;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (_isAlive)
        {
            navMeshAgent.SetDestination(_target.transform.position);
        }
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
                _animator.applyRootMotion = false;
                _animator.SetBool("Death", true);
                gameObject.GetComponentInChildren<EnemyDamage>()._enemyDamage = 0;
                Invoke("Death", 0.1f);
            }
        }
    }
    private void Death()
    {
        _animator.SetBool("Death", false);
        _target.GetComponent<IEnemyDamage>().Kills(1);
    }
}
