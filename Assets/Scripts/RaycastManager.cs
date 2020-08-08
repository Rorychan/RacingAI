using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    public float Forward, ForwardLeft, ForwardRight, Left, Right;
    public float Distance;
    // Start is called before the first frame update
    void Start()
    {
        Distance = 3;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDistances();
    }

    private void UpdateDistances() 
    {
        Forward = GetRaycastDistance(transform.up);
        ForwardLeft = GetRaycastDistance(Quaternion.Euler(0, 0, 60) * transform.up);
        ForwardRight = GetRaycastDistance(Quaternion.Euler(0, 0, -60) * transform.up);
        Right = GetRaycastDistance(Quaternion.Euler(0, 0, 30) * transform.up);
        Left = GetRaycastDistance(Quaternion.Euler(0, 0, -30) * transform.up);
        Debug.DrawRay(transform.position+transform.up*0.5f, transform.up, Color.red);
    }

    private float GetRaycastDistance(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.up*0.5f, direction, Distance);
        if (hit.collider != null)
        {
            return hit.distance;
        }

        return 0;
    }
}
