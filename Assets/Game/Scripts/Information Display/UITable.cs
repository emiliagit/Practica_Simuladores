using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITable : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab; // Prefab de la celda
    [SerializeField] private Transform tablePanel; // Panel donde se colocarán las celdas
    [SerializeField] private LastShootInfo shotInfo;

    private void Start()
    {
        LoadTableData();
    }

    private void LoadTableData()
    {
        // Limpiar celdas existentes
        foreach (Transform child in tablePanel)
        {
            Destroy(child.gameObject);
        }

        // Crear y llenar celdas con datos
        CreateCell("Force", shotInfo.Force.ToString("0.##"));
        CreateCell("X Angle", shotInfo.X_Angle.ToString("0.##"));
        CreateCell("Y Angle", shotInfo.Y_Angle.ToString("0.##"));
        CreateCell("Impact Force", shotInfo.ImpactForce.ToString("0.##"));
    }

    private void CreateCell(string label, string value)
    {
        GameObject cell = Instantiate(cellPrefab, tablePanel);
        TextMeshProUGUI[] texts = cell.GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = label;
        texts[1].text = value;
    }
}
