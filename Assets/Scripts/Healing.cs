using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    [SerializeField] private GameObject _player = null;
    [SerializeField] private float _healing = 15;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player.GetComponent<IHealing>().Healing(_healing);
            Destroy(gameObject);
        }
    }
}
