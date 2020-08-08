using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synapse 
{
    
    public float Weight;

    public Synapse() 
    {
        
        Weight = Random.Range(-10f, 10f);
    }

    public Synapse( float weight) 
    {
        
        Weight = weight;
    }
}
