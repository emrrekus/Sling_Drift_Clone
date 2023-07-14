using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DriftCar : MonoBehaviour
{
    [Header("Car Drift Ancher")] [SerializeField]
    protected Transform _target;

    public LineRenderer lineRenderer;
    public DistanceJoint2D distanceJoint;


    [Header("Car Drift Rotation")] protected Vector3 direction;
    [SerializeField] protected float MoveSpeed;
    [SerializeField] protected float Traction;

    protected bool isOnDrift;
    public bool isOnRotationControl;


    private FindClosesDriftPoint findClosestPoint;
    private CornerRotate cornerRotate;


    [Header("Car Drift Rotation Control")] [SerializeField]
    protected float smoothSpeed;

    [SerializeField] protected float completionThreshold;
    [SerializeField] protected float ancherAngle;
    protected bool isTurnComplete;


    private void Awake()
    {
        cornerRotate = GetComponent<CornerRotate>();
        findClosestPoint = FindObjectOfType<FindClosesDriftPoint>();
    }

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        distanceJoint = GetComponent<DistanceJoint2D>();

        distanceJoint.enabled = false;
    }

    private void OnEnable()
    {
        if (findClosestPoint != null)
        {
            findClosestPoint.OnClosestDriftPointFound += TheNearestDriftAnchor;
            findClosestPoint.OnClosestDriftPointAngle += TheNearestDriftAnchorAngle;
        }


        if (cornerRotate != null)
            cornerRotate.OnMovementDirectionChange += RotateCar;
    }

    private void OnDisable()
    {
        if (findClosestPoint != null)
        {
            findClosestPoint.OnClosestDriftPointFound -= TheNearestDriftAnchor;
            findClosestPoint.OnClosestDriftPointAngle -= TheNearestDriftAnchorAngle;
        }

        if (cornerRotate != null)
            cornerRotate.OnMovementDirectionChange -= RotateCar;
    }

    protected void HookOn()
    {
        distanceJoint.enabled = true;
        distanceJoint.connectedAnchor = _target.position;
        DriftAncher();
        LineRendererSetPosition();
    }

    protected void HookOff()
    {
        isOnRotationControl = true;
        distanceJoint.enabled = false;
        lineRenderer.positionCount = 0;
    }

    protected void LineRendererSetPosition()
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


    private void TheNearestDriftAnchor(Transform closestPoint)
    {
        _target = closestPoint;
    }

    private void TheNearestDriftAnchorAngle(byte Angle)
    {
        ancherAngle = Angle;
    }

    private void RotateCar(Vector3 direction)
    {
        this.direction = direction;
    }

    public void CanitDrift(bool canDrift)
    {
        isOnDrift = canDrift;
    }

    protected void DriftRotationControlCar()
    {
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y,
            ancherAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, smoothSpeed * Time.deltaTime);

        float angleDifference = Quaternion.Angle(transform.rotation, newRotation);
        if (angleDifference < completionThreshold)
        {
            isOnRotationControl = false;
            // Dönüş tamamlandı
            Debug.Log("Dönüş tamamlandı!");
        }
    }
}