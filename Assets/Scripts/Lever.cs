using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private SimpleDoor _door = null;

    private Animator _animator = null;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _door.isActive = !_door.isActive;
            if (_animator.GetBool("LeverUpDown"))
            _animator.SetBool("LeverUpDown", false);
            else _animator.SetBool("LeverUpDown", true);
        }
        
    }
}
