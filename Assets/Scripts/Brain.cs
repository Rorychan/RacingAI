using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Brain : MonoBehaviour
{
    private CarController _carController;
    private RaycastManager _raycastManager;
    private float[] Inputs;
    public List<NetLayer> layers = new List<NetLayer>();

    public float rotationMultiplyer;

    public float rotationCoef;

    // Start is called before the first frame update
    void Start()
    {
        _raycastManager = GetComponent<RaycastManager>();
        _carController = GetComponent<CarController>();
        Inputs = new float[5];
        SetLayers();
    }

    private void SetLayers() 
    {
        layers.Add(new NetLayer(4, Inputs.Length));
        layers.Add(new NetLayer(4, layers[0].Neurons.Count));
        layers.Add(new NetLayer(1, layers[1].Neurons.Count));
        
    }

    private void UpdateInputs()
    {
        Inputs[0] = _raycastManager.Forward;
        Inputs[1] = _raycastManager.ForwardLeft;
        Inputs[2] = _raycastManager.ForwardRight;
        Inputs[3] = _raycastManager.Left;
        Inputs[4] = _raycastManager.Right;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInputs();
        UpdateRotation();
    }
    private void UpdateRotation() 
    {
        for(int i = 0; i < layers.Count; i++) 
        {
            var layer = layers[i];
            if (i == 0)
            {
                layer.ForwardProp(Inputs.ToList());
                if (i == layers.Count - 1)
                {
                    rotationCoef = layer.Output.First();
                }
                continue;
            }

            var prevLayer = layers[i - 1];
            layer.ForwardProp(prevLayer.Output);

            if (i == layers.Count - 1) 
            {
                rotationCoef = layer.Output.First();
            }
        }
        Debug.Log(rotationCoef);
        _carController.Rotation = ((rotationCoef - 0.5f)*2) * rotationMultiplyer;
    }
}
