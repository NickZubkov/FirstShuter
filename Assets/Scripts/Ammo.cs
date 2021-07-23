using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private GameObject _player = null;
    [SerializeField] private float _bullets = 20;
    [SerializeField] private float _mines = 2;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _player.GetComponent<IAmmo>().Ammo(_bullets, _mines);
            Destroy(gameObject);
        }
    }
}
