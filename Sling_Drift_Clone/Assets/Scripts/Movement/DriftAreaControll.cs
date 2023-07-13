using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftAreaControll : MonoBehaviour
{
    private bool isDrift;

    public bool ISDRİFT => isDrift;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Car"))
        {
            isDrift = true;
        }
        else
        {
            isDrift = false;
        }
    }
}