using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalScore : MonoBehaviour
{

    public static int CurrentScore;
    public int InternalScore;
    public GameObject ScoreText;

    void Update()
    {
        InternalScore = CurrentScore;
        ScoreText.GetComponent<Text>().text = "" + InternalScore;
    }
}