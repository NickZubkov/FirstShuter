using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    [SerializeField] private Image _winImage = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _winImage.gameObject.SetActive(true);
            _winImage.CrossFadeAlpha(255f, 3f, false);
            Invoke("NewGame", 3.5f);
        }
    }
    private void NewGame()
    {
        SceneManager.LoadScene(0);
    }
}
