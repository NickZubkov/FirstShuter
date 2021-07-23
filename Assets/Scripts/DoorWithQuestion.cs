using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithQuestion : MonoBehaviour, IKey
{
    private Animator _animator = null;
    private bool _getAnswer = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (_getAnswer)
            _animator.SetBool("DoorOpenClose", true);
        else _animator.SetBool("DoorOpenClose", false);
    }

    
    public void GetKey()
    {
        _getAnswer = !_getAnswer;
    }
}
