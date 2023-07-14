using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentControl : MonoBehaviour
{
    public GameManager _gameManager;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Forward") && !other.CompareTag("Back"))
        {
            _gameManager.CarCrash(true);
          _gameManager.PanelOpen(0);
            Time.timeScale = 0f;

        }
        else if (other.CompareTag("Finish"))
        {
            _gameManager.FinishLevel(true);
        }
    }
}