using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu = null;
    [SerializeField] private GameObject _settingMenu = null;
    [Space]
    [SerializeField] private Toggle _muteToggle = null;
    [SerializeField] private Slider _sliderVolume = null;
    [Space]
    [SerializeField] private Button _exitButton = null;

    private void Awake()
    {
        _exitButton.onClick.AddListener(ExitButton);
        _muteToggle.onValueChanged.AddListener(MuteGame);
        _sliderVolume.onValueChanged.AddListener(SliderVolume);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.Find("Player").GetComponent<Player>()._fire = false;
            Time.timeScale = 1f;
            _settingMenu.SetActive(false);
            _mainMenu.SetActive(false);
        }
    }
    private void MuteGame(bool value)
    {
        GameSettings.instance.mute = value;
    }
    private void ExitButton()
    {
        _settingMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }
    private void SliderVolume(float value)
    {
        GameSettings.instance.volume = value;
    }
}
