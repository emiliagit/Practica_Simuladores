
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformationDisplay : MonoBehaviour
{
    public TextMeshProUGUI infoTextAngleX;
    public TextMeshProUGUI infoTextAngleZ;
    public TextMeshProUGUI infoTextPower;
    public TextMeshProUGUI infoTextColision;
    public Slider angleXSlider;
    public Slider angleZSlider;
    public Slider powerSlider;

    private bool hasCollided = false;
    private float lastAngleX;
    private float lastAngleZ;

    void Start()
    {
        // Inicializar los valores de los ángulos
        lastAngleX = angleXSlider.value;
        lastAngleZ = angleZSlider.value;
    }

    void Update()
    {
        // Comprobar si los ángulos han cambiado
        if (lastAngleX != angleXSlider.value || lastAngleZ != angleZSlider.value)
        {
            hasCollided = false;  // Restablecer el estado de colisión
        }

        // Actualizar los valores de los ángulos
        lastAngleX = angleXSlider.value;
        lastAngleZ = angleZSlider.value;

        // Actualizar la información en pantalla
        infoTextAngleX.text = "Ángulo X: " + angleXSlider.value;
        infoTextAngleZ.text = "\nÁngulo Z: " + angleZSlider.value;
        infoTextPower.text = "\nPotencia: " + powerSlider.value;
        infoTextColision.text = (hasCollided ? "\n¡Colisión detectada con el objetivo!" : "");
    }

    public void ReportCollision()
    {
        hasCollided = true;
    }
}
