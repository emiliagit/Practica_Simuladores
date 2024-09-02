using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public InformationDisplay infoDisplay;  // Referencia al script que muestra la información

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            // Notificar al script de información sobre la colisión
            infoDisplay.ReportCollision();
        }
    }
}
