using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerRotate : MonoBehaviour
{
    public event Action<Vector3> OnMovementDirectionChange;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Forward"))
        {
            ChangeMovementDirection(Vector3.forward);
        }
        else if(col.gameObject.CompareTag("Back"))
        {
            ChangeMovementDirection(Vector3.back);
        }
    }
    
    private void ChangeMovementDirection(Vector3 direction)
    {
        
        OnMovementDirectionChange?.Invoke(direction);
    }
}
