using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformationDisplay : MonoBehaviour
{
    [SerializeField] private GameObject statsPanel;
    [SerializeField] private LastShootInfo shotInfo;
    private float lastXAngle;
    private float lastYAngle;

    private CanonController projectileThrow;
    private FireCanon projectilePower;

    [SerializeField] private GameObject LinePrefab;
    [SerializeField] private Transform tablePanel;

    [System.Obsolete]
    private void Start()
    {
        projectileThrow = FindObjectOfType<CanonController>();
        projectilePower = FindObjectOfType<FireCanon>();

        shotInfo.ResetValues();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            ToggleUI();

        SetAnglesUI();
    }

    private void ToggleUI()
    {
        if (statsPanel.activeSelf)
            statsPanel.SetActive(false);
        else
            statsPanel.SetActive(true);
    }

   
    private void SetAnglesUI()
    {
        float xAngleToDisplay = projectileThrow.sliderX.value;

        if (xAngleToDisplay > 180f)
            xAngleToDisplay -= 360f;

        lastXAngle = xAngleToDisplay;
       
        float yAngleToDisplay = projectileThrow.sliderY.value;

        if (yAngleToDisplay <= 360f && yAngleToDisplay > 305f)
            yAngleToDisplay = Mathf.Abs(yAngleToDisplay - 360f);
        else
            yAngleToDisplay = -yAngleToDisplay;

        lastYAngle = yAngleToDisplay;
       
    }

    public void SetImpactForceUI(float force)
    {
        
        Debug.Log("force");
        SetLastShotInfo(force);
    }

    private void SetLastShotInfo(float lastImpactForce)
    {
        shotInfo.Force = projectilePower.powerSlider.value;
        shotInfo.X_Angle = lastXAngle;
        shotInfo.Y_Angle = lastYAngle;
        shotInfo.ImpactForce = lastImpactForce;
    }
    public void LoadTableData()
    {
        GameObject newLine = Instantiate(LinePrefab, tablePanel.transform);

        TextMeshProUGUI[] texts = newLine.GetComponentsInChildren<TextMeshProUGUI>();

        texts[0].text = shotInfo.X_Angle.ToString();
        texts[1].text = shotInfo.Y_Angle.ToString();
        texts[2].text = shotInfo.Force.ToString();
        texts[3].text = shotInfo.ImpactForce.ToString();
    }
}
