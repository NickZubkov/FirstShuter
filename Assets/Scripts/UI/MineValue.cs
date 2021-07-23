using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MineValue : MonoBehaviour
{
    [SerializeField] private GameObject _player = null;

    private string _mine = null;

    private void FixedUpdate()
    {
        _mine = Convert.ToString(_player.GetComponent<Player>()._mineCount);
        GetComponent<Text>().text = _mine;
    }
}
