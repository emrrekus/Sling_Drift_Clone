using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosesDriftPoint : MonoBehaviour
{
    public GameObject player;
    public event Action<Transform> OnClosestDriftPointFound;
    public event Action<byte> OnClosestDriftPointAngle;
    public GameObject[] driftPoints;

    private byte closestPointAngle;

    private GameObject _nearPoint;

    Transform closestPoint = null;

    private void Update()
    {
        FindAndTriggerClosestPointEvent();
        FindAndTriggerClosestPointAngle();
    }

    private void FindAndTriggerClosestPointEvent()
    {
        FindingTheClosetObject();

        OnClosestDriftPointFound?.Invoke(closestPoint);
    }

    private void FindAndTriggerClosestPointAngle()
    {
        FindPointAngle();

        OnClosestDriftPointAngle?.Invoke(closestPointAngle);
    }

    private void FindPointAngle()
    {
        DriftPointCurve driftPointCurve = _nearPoint.GetComponent<DriftPointCurve>();
        if (driftPointCurve != null)
        {
            closestPointAngle = driftPointCurve.curveAngle;
        }
    }


    private void FindingTheClosetObject()
    {
        float closestDistance = Mathf.Infinity;

        foreach (GameObject point in driftPoints)
        {
            float distance = Vector3.Distance(player.transform.position, point.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPoint = point.transform;
                _nearPoint = point;

                DriftPointCurve driftPointCurve = point.GetComponent<DriftPointCurve>();
                if (driftPointCurve != null)
                {
                    closestPointAngle = driftPointCurve.curveAngle;
                }
            }
        }
    }
}