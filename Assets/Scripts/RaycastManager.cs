using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    public float Forward;
    public float ForwardLeft;
    public float ForwardRight;
    public float Left;
    public float Right;
    
    public float RaycastDistance = 3;

    [SerializeField] private Transform forwardSensor;
    [SerializeField] private Transform forwardLeftSensor;
    [SerializeField] private Transform forwardRightSensor;
    [SerializeField] private Transform backLeftSensor;
    [SerializeField] private Transform backRightSensor;
    void Update()
    {
        UpdateDistances();
    }

    private void UpdateDistances() 
    {
        Forward = GetRaycastDistance(forwardSensor);
        ForwardLeft = GetRaycastDistance(forwardLeftSensor);
        ForwardRight = GetRaycastDistance(forwardRightSensor);
        Right = GetRaycastDistance(backLeftSensor);
        Left = GetRaycastDistance(backRightSensor);
    }

    private float GetRaycastDistance(Transform sensor)
    {
        RaycastHit2D hit = Physics2D.Raycast(sensor.position, sensor.up, RaycastDistance);
        if (hit.collider != null)
        {
            return RaycastDistance/hit.distance;
        }

        return 0;
    }
}
