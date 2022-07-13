using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// Data Structure used for serialize user data.
/// </summary>
[System.Serializable]
public class UserData
{
    public int id;
    public string first_name;
    public string last_name;
    public string email;
    public string gender;
    public int age;

    #region Override
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("||| Datos de Usuario. |||" + "\n");
        sb.Append("ID: " + id + "\n");
        sb.Append("First Name: " + first_name + "\n");
        sb.Append("Last Name: " + last_name + "\n");
        sb.Append("Email: " + email + "\n");
        sb.Append("Gender: " + gender + "\n");
        sb.Append("Age: " + age + "\n");

        return sb.ToString();
    }

    #endregion
}
