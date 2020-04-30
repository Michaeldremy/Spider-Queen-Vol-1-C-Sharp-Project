using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZScore100 : MonoBehaviour
{
    void DeductPoints(int DamageAmount)
    {
        GlobalScore.CurrentScore += 100;
    }

}
