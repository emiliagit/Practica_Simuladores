using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITable : MonoBehaviour
{
    [SerializeField] private GameObject LinePrefab; // Prefab de la celda
    [SerializeField] private Transform tablePanel; // Panel donde se colocarán las celdas
    [SerializeField] private LastShootInfo shotInfo;

    private void Start()
    {
        LoadTableData();
    }

    private void LoadTableData()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            GameObject newLine = Instantiate(LinePrefab, tablePanel);

            TextMeshProUGUI[] texts = newLine.GetComponentsInChildren<TextMeshProUGUI>();

            texts[0].text = shotInfo.ShotIndex.ToString();
            texts[1].text = shotInfo.X_Angle.ToString();
            texts[2].text = shotInfo.Y_Angle.ToString();
            texts[3].text = shotInfo.Force.ToString();
            texts[4].text = shotInfo.ImpactForce.ToString();
        }
       


    }


}
