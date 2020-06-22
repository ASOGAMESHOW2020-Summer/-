using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probability : MonoBehaviour
{
    public bool Probailitys(float Percent)
    {
        float fProbabilityRate = UnityEngine.Random.value * 100.0f;

        if (Percent == 100.0f && fProbabilityRate == Percent)
        {
            return true;
        }
        else if (fProbabilityRate < Percent)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
