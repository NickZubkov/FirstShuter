using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu = null;
    [SerializeField] private GameObject _settingMenu = null;
    [Space]
    [SerializeField] private Button _newGame = null;
    [SerializeField] private Button _settings = null;
    [SerializeField] private Button _exitGame = null;
    [SerializeField] private Button _visualiser = null;

    private void Awake()
    {
        _newGame.onClick.AddListener(NewGame);
        _settings.onClick.AddListener(GameSettings);
        _exitGame.onClick.AddListener(ExitGame);
        _visualiser.onClick.AddListener(Visualiser);
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Locked;
            GameObject.Find("Player").GetComponent<Player>()._fire = false;
            Time.timeScale = 1f;
            _mainMenu.SetActive(false);
        }
    }
    private void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    private void GameSettings()
    {
        _mainMenu.SetActive(false);
        _settingMenu.SetActive(true);
    }
    private void ExitGame()
    {
        Application.Quit();
    }
    private void Visualiser()
    {
        SceneManager.LoadScene(2);
    }
}
