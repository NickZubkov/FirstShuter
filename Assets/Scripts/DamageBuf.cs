using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBuf : MonoBehaviour
{
    [SerializeField] private GameObject _player = null;
    [SerializeField] private int _damageBuf = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player.GetComponent<IDamageBuf>().DamageBuf(_damageBuf);
            Destroy(gameObject);
        }
    }
}
