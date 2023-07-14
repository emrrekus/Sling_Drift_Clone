using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftHook : DriftCar
{
    private void Update()
    {
        if (isOnDrift && Input.GetMouseButton(0))
            HookOn();

        else if (Input.GetMouseButtonUp(0))
            HookOff();

        
        if (isOnRotationControl&&isOnDrift)
            DriftRotationControlCar();
    }
}