using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DriftCar : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [Header("Car Drift Ancher")] [SerializeField]
    protected Transform _target;

    [SerializeField] protected LineRenderer lineRenderer;
    [SerializeField] protected DistanceJoint2D distanceJoint;

    [Header("Car Drift Rotation")] 
    protected Vector3 direction;
    [SerializeField] protected float MoveSpeed;
    [SerializeField] protected float Traction;


    private void Awake()
    {
        lineRenderer = _player.gameObject.GetComponent<LineRenderer>();
        distanceJoint = _player.gameObject.GetComponent<DistanceJoint2D>();
        distanceJoint.enabled = false;
    }
    
    protected void HookOn()
    {
        distanceJoint.enabled = true;
        distanceJoint.connectedAnchor = _target.position;
        LineRendererSetPosition();
        DriftAncher();
    }
    
    protected void HookOff()
    {
        distanceJoint.enabled = false;
        lineRenderer.positionCount = 0;
    }

    private void LineRendererSetPosition()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, _target.position);
        lineRenderer.SetPosition(1, transform.position);
    }

    private void DriftAncher()
    {
        float rotationAmount = MoveSpeed * Traction * Time.deltaTime * 10;
        transform.RotateAround(_target.position, direction, rotationAmount);
    }
    
}