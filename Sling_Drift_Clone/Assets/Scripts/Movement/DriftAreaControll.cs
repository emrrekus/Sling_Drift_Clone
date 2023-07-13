using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftAreaControll : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        DriftCar driftCar = col.gameObject.GetComponent<DriftCar>();
        if (col.gameObject.CompareTag("Car"))
        {
            driftCar.CanitDrift(true);
        }
       
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        DriftCar driftCar = col.gameObject.GetComponent<DriftCar>();
        if (col.gameObject.CompareTag("Car"))
        {
            driftCar.CanitDrift(false);
        }
      
    }
}