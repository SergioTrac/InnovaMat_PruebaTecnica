using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Show a text when the session info data changed.
/// </summary>
public class UI_UserDataDisplay : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private SessionInfo sessionInfo;

    [Header("Text Mesh")]
    [SerializeField] private TextMeshProUGUI textMesh;

    private void Start()
    {
        if (sessionInfo != null)
            sessionInfo.OnInfoChanged.AddListener(SetText);
    }

    private void SetText()
    {
        textMesh.SetText(sessionInfo.GetUserData().ToString());
    }
}
