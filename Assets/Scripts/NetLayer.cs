using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NetLayer 
{
    private int _neuronsCount;
    public List<Neuron> Neurons = new List<Neuron>();
    public List<float> Output = new List<float>();
    public NetLayer(int neuronsCount, int inputCount) 
    {
        _neuronsCount = neuronsCount;
        for (int i = 0; i < neuronsCount; i++) 
        {
            Neurons.Add(new Neuron(inputCount));
        }
    }

    public void ForwardProp(List<float> inputs)
    {
        Output.Clear();
        if(_neuronsCount == 1)
        {
            var finalNeuron = Neurons.First();
            finalNeuron.Input = inputs;
            Output.Add(finalNeuron.GetFinalResult());
        }

        foreach (var neuron in Neurons) 
        {
            neuron.Input = inputs;
            Output.Add(neuron.GetOutput());
        }
    }
}
