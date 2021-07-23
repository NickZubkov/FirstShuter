using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] public int _enemyDamage = 1;
    [SerializeField] private int _damageRollbackTime = 1;
    
    private bool _damageRollback = true;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && _damageRollback)
        {
            StartCoroutine(EnemyDamageGive());
            _damageRollback = !_damageRollback;
        }
    }
    private IEnumerator EnemyDamageGive()
    {
        GameObject.Find("Player").GetComponent<IEnemyDamage>().EnemyDamage(_enemyDamage);
        yield return new WaitForSeconds(_damageRollbackTime);
        _damageRollback = !_damageRollback;
    }
    
}
