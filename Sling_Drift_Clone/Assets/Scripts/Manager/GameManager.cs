using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // [SerializeField] private GameObject[] _panels;
    [SerializeField] private GameObject panel;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private GameObject player;
    private bool _finishLevel;
    private bool _carİsCrash;


   

    public void PanelOpen(int process)
    {
        switch (process)
        {
            case 0:

                panel.SetActive(true);
                Debug.Log("Çalıştı");
                break;
            default:
                break;
        }
    }

    public void FinishLevel(bool isFinish)
    {
        isFinish = _finishLevel;
    }

    public void CarCrash(bool carCrash)
    {
        Debug.Log("Çalıştı");
        _carİsCrash = carCrash;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RetryGame()
    {
        player.transform.position = _startPoint.transform.position;
        panel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}