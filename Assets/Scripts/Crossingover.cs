using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossingover 
{
    
    public List<Brain> Creatures;
    List<float> Genes1;
    List<float> Genes2;
    List<float> NewGenes1;
    List<float> NewGenes2;

    public Crossingover(List<Brain> creatures)
    {
        Creatures = creatures;
    }


    public void GetGenes(List<Brain> creatures) 
    {
        List<float> totalgenes = null;
        Genes1 = null;
        Genes2 = null;

        foreach (var creature in creatures)
        {
            foreach (var layer in creature.layers)
            {
                foreach (var neuron in layer.Neurons) 
                {
                    foreach (var synapse in neuron.Synapses)
                    {
                        totalgenes.Add(synapse.Weight);
                    }
                }
            }
        }
        for (int i = 0; i < totalgenes.Count; i++)
        {
            if (i < totalgenes.Count / 2)
            {
                Genes1.Add(totalgenes[i]);
            }
            else 
            {
                Genes2.Add(totalgenes[i]);
            }
        }

    }
    public void Cross() 
    {
        int slicePoint = Random.Range(1, Genes1.Count - 1);
        NewGenes1 = null;
        NewGenes2 = null;

        for (int i = 0; i < slicePoint; i++) 
        {
            NewGenes1.Add(Genes1[i]);
            NewGenes2.Add(Genes2[i]);
        }
        for (int i = slicePoint; i < Genes1.Count; i++) 
        {
            bool similarNewGenes1Check = false;
            bool similarNewGenes2Check = false;
            for (int j = 0; j < slicePoint; j++) 
            {
                if ((Genes2[i] > Genes1[j] - 0.02f) && (Genes2[i] < Genes1[j] + 0.02f)) 
                {
                    similarNewGenes1Check = true;
                }
                if ((Genes1[i] > Genes2[j] - 0.02f) && (Genes1[i] < Genes2[j] + 0.02f))
                {
                    similarNewGenes2Check = true;
                }


            }
            if (similarNewGenes1Check)
            {
                NewGenes1.Add(Genes2[i]);
            }
            if (similarNewGenes2Check) 
            {
                NewGenes2.Add(Genes1[i]);
            }
        }

    }


}
