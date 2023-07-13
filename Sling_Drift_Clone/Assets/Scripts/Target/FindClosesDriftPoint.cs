using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosesDriftPoint : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    public event Action<Transform> OnClosestDriftPointFound;
    public Transform[] driftPoints;

    private void Update()
    {
        FindAndTriggerClosestPointEvent();
    }

    private void FindAndTriggerClosestPointEvent()
    {
        float closestDistance = Mathf.Infinity; 
        Transform closestPoint = null;

        foreach (Transform point in driftPoints)
        {
            float distance = Vector3.Distance(_player.transform.position, point.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPoint = point;
            }
        }

        if (closestPoint != null)
        {
            OnClosestDriftPointFound?.Invoke(closestPoint);
        }
    }
}
