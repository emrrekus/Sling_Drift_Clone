using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftHook : DriftCar
{
    private FindClosesDriftPoint findClosestPoint;
    private CornerRotate cornerRotate;

    void Awake()
    {
        cornerRotate = GetComponent<CornerRotate>();
        findClosestPoint = FindObjectOfType<FindClosesDriftPoint>();
    }


    private void OnEnable()
    {
        if (findClosestPoint != null)
            findClosestPoint.OnClosestDriftPointFound += TheNearestDriftAnchor;
        
        if (cornerRotate != null)
            cornerRotate.OnMovementDirectionChange += RotateCar;
    }

    private void OnDisable()
    {
        if (findClosestPoint != null)
            findClosestPoint.OnClosestDriftPointFound -= TheNearestDriftAnchor;
        
        if (cornerRotate != null)
            cornerRotate.OnMovementDirectionChange -= RotateCar;
    }


    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (Input.GetMouseButton(0) || touch.phase == TouchPhase.Began)
            {
                HookOn();
            }
            else if (Input.GetMouseButtonUp(0) || touch.phase==TouchPhase.Ended)
            {
                HookOff();
            }
        }
        
      
    }


    private void TheNearestDriftAnchor(Transform closestPoint)
    {
        _target = closestPoint;
    }

    private void RotateCar(Vector3 direction)
    {
        this.direction = direction;
    }
}