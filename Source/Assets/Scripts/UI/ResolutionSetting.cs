using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionSetting : MonoBehaviour
{
    private void Awake()
    {
    #if UNITY_STANDALONE
        int height = Screen.height;
        int width = (int)((float) height / 16 * 9);
        Screen.SetResolution(width, height, false);
        Screen.fullScreen = false;
    #endif
    }
}

