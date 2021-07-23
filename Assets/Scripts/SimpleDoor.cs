using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDoor : MonoBehaviour
{
    public bool isActive = false;

    private Animator _doorMoov = null;

    private void Awake()
    {
        _doorMoov = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isActive)
            _doorMoov.SetBool("DoorOpenClose", true);
        else _doorMoov.SetBool("DoorOpenClose", false);
    }
}
