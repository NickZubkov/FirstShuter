using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

public class Visualiser : MonoBehaviour
{
    [SerializeField] private Button _exitButton = null;

    public float minHigh = 10f;
    public float maxHigh = 450f;
    public Color visualiserColor = Color.gray;
    public RectTransform[] visualiserObjects = null;
    public float updateSensitivity = 0.5f;
    private int visualiserSimples = 64;

    private float[] spectr;

    private void Awake()
    {
        _exitButton.onClick.AddListener(MainMenu);
    }
    private void Update()
    {
        spectr = GetComponent<AudioSource>().GetSpectrumData(visualiserSimples, 0, FFTWindow.Rectangular);
        for (int i =0; i < visualiserObjects.Length; i++)
        {
            Vector2 newSize =visualiserObjects[i].GetComponent<RectTransform>().rect.size;
            newSize.y = Mathf.Clamp(Mathf.Lerp(newSize.y, minHigh + (spectr[i] * (maxHigh - minHigh) * 5f), updateSensitivity), minHigh, maxHigh);
            visualiserObjects[i].GetComponent<RectTransform>().sizeDelta = newSize;
            visualiserObjects[i].GetComponentInChildren<Image>().color = visualiserColor;
        }
    }
     private void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
