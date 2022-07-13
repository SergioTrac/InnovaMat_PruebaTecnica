using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

/// <summary>
/// Function js library of general Behaviour for the WebGL Build.
/// </summary>
public class WebGLGeneralBehaviour : MonoBehaviour
{
    
    [DllImport("__Internal")]
    private static extern void closewindow();

    public void CloseTab()
    {
        closewindow();
    }
    
}
