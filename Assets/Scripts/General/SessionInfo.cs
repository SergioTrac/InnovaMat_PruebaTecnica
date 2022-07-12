using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SessionInfo", menuName = "Data/SessionInfo", order = 1)]
public class SessionInfo : ScriptableObject
{
    public UserData UserData { get; set; }
}
