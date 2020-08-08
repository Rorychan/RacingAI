using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neuron 
{
    public List<float> Input = new List<float>();
    public List<Synapse> Synapses = new List<Synapse>();

    public Neuron(int inputCount) 
    {
        for (int i = 0; i < inputCount; i++) 
        {
            Synapses.Add(new Synapse());
        }
    }

    public float GetOutput() 
    {
        float result = 0;
        for (int i = 0; i < Synapses.Count; i++) 
        {
            float value = (float)Input[i];
            result += value * Synapses[i].Weight;
        }

        if (result <= 0) return 0;

        return result;
    }

    public float GetFinalResult()
    {
        float result = 0;
        for (int i = 0; i < Synapses.Count; i++)
        {
            float value = (float)Input[i];
            result += value * Synapses[i].Weight;
        }

        return 1 / (1 + Mathf.Exp(-result));
    }
}
