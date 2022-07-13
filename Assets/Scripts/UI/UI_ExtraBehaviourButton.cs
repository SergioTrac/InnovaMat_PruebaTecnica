using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_ExtraBehaviourButton : MonoBehaviour
{
    [Header("Behaviour per platform")]
    [SerializeField] private UnityEvent OnButtonPress_Android;
    [SerializeField] private UnityEvent OnButtonPress_WebGL;

    public void OnButtonPress()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            OnButtonPress_Android?.Invoke();
        }
        else if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            OnButtonPress_WebGL?.Invoke();
        }
        else
            Debug.LogWarning("UI_ExtraBehaviourButton: Undefined behaviour for the current platform");
    }
}
