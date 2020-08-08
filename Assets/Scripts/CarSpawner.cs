using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject CarPrefab;
    public int CarsCount;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < CarsCount; i++) 
        {
            Instantiate(CarPrefab).transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
