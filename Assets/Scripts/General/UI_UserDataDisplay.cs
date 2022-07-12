using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_UserDataDisplay : MonoBehaviour
{
    [SerializeField] private SessionInfo sessionInfo;
    [SerializeField] private TextMeshProUGUI textMesh;

    private void Start()
    {
        if (sessionInfo != null)
            sessionInfo.OnInfoChanged.AddListener(SetText);
    }

    private void SetText()
    {
        textMesh.SetText(sessionInfo.GetUserData().first_name);
    }
}
