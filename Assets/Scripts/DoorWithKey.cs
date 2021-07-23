using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithKey : MonoBehaviour, IKey
{
    private Animator _animator = null;
    private bool _getKey = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" && !_animator.GetBool("DoorOpenClose") && _getKey)
            _animator.SetBool("DoorOpenClose", true);
        else _animator.SetBool("DoorOpenClose", false);
    }
    public void GetKey()
    {
        _getKey = true;
    }
}
