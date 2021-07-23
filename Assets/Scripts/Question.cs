using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    [SerializeField] private GameObject _door = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Answer"))
        {
            _door.GetComponent<IKey>().GetKey();
        }
    }
}
