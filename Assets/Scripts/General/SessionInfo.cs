using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Store the information of the current session.
/// </summary>
[CreateAssetMenu(fileName = "SessionInfo", menuName = "Data/SessionInfo", order = 1)]
public class SessionInfo : ScriptableObject
{
    [Header("Data")]
    private UserData userData;


    public UnityEvent OnInfoChanged;

    #region Getters and Setters

    public UserData GetUserData()
    {
        return userData;
    }

    public void SetUserData(UserData _userData)
    {
        userData = _userData;
        OnInfoChanged?.Invoke();
    }

    #endregion

}
