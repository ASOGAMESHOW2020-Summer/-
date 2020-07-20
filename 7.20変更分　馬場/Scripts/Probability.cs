/*確率を計算するスクリプト*/
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
}
