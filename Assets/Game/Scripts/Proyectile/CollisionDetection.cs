using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public InformationDisplay infoDisplay;  // Referencia al script que muestra la informaci�n

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            // Notificar al script de informaci�n sobre la colisi�n
            infoDisplay.ReportCollision();
        }
    }
}
