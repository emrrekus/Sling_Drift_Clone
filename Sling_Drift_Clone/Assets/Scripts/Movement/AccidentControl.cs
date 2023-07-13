using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Forward") && !other.CompareTag("Back"))
        {
            Debug.Log(other.name);
            Time.timeScale = 0f;
        }
    }
}
