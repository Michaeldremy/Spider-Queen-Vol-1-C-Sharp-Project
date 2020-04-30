using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZScore25 : MonoBehaviour
{
    void DeductPoints(int DamageAmount)
    {
        GlobalScore.CurrentScore += 25;
    }
}
