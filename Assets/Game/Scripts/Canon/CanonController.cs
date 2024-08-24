using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanonController : MonoBehaviour
{
    /*public GameObject cannon;*/ // El ca��n que deseas mover
    public Slider sliderX;    // Slider para controlar la posici�n en X
    public Slider sliderY;    // Slider para controlar la posici�n en Y

    void Start()
    {

    }
    private void Update()
    {
        rotation();
    }

    void rotation()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, sliderY.value, transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(sliderX.value, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
