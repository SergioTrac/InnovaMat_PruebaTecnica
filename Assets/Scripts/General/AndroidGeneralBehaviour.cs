using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Function library of general Behaviour for the Android Build.
/// </summary>
public class AndroidGeneralBehaviour : MonoBehaviour
{
    public void CloseApplication()
    {
        Application.Quit();
    }
}
