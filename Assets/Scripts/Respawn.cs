using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition = null;
    [SerializeField] private GameObject _enemyPref = null;
    [SerializeField] private float _enemyNum = 4;
    [SerializeField] public Transform[] _wayPoints = null;

    private float _enemyCounter = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            InvokeRepeating("EnemySpawn", 2, 2);
        }
    }
    private void EnemySpawn()
    {
        var enemy = Instantiate(_enemyPref, _spawnPosition.position, Quaternion.identity).GetComponent<Enemy>();
        enemy.Init(_wayPoints);
        _enemyCounter++;
        if (_enemyCounter == _enemyNum)
        {
            Destroy(gameObject);
        }
    }
}
