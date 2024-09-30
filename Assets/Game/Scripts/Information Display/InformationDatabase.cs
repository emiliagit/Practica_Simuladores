using Models;
using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InformationDatabase : MonoBehaviour
{
    public LastShootInfo shootInfo;
    public TMP_InputField inputIndex;

    private readonly string basePath = "https://database-simuladores-default-rtdb.firebaseio.com/";

    private ShootInfoToDisplay shotToRead = new();

    private void LogMessage(string title, string message)
    {
#if UNITY_EDITOR
        EditorUtility.DisplayDialog(title, message, "Ok");
#else
		Debug.Log(message);
#endif
    }
    public void SaveData()
    {
        RestClient.Put(basePath + "/Shot " + shootInfo.ShotIndex.ToString() + ".json", shootInfo);
        Debug.Log($"Shot {shootInfo.ShotIndex} values have been saved succesfully");
        shootInfo.ShotIndex++;
    }

    public void ReadData()
    {
        RestClient.Get<ShootInfoToDisplay>(basePath + "/Shot%20" + inputIndex.text + ".json").Then(response =>
        {
            shotToRead = response;
            this.LogMessage($"Shot values", $"Index: {inputIndex.text}\n" +
                $"Force: {shotToRead.Force}\n" +
                $"X Angle: {shotToRead.X_Angle}\n" +
                $"Y Angle: {shotToRead.Y_Angle}\n" +
                $"Impact force: {shotToRead.ImpactForce}");
        });
    }
}
