using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanonController : MonoBehaviour
{
   
    public Slider sliderX;    
    public Slider sliderY;   
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
