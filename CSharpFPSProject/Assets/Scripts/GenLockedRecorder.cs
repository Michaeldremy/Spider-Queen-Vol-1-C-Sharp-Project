using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.Media;
#endif

public class GenLockedRecorder : MonoBehaviour
{
    void Start()
    {
        // Make the game run as fast as possible
        Application.targetFrameRate = 60;
    }
}