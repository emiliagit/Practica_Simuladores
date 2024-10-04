using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private InformationDisplay statsUI;
    private bool collisioned;

    [System.Obsolete]
    private void Start()
    {
        statsUI = FindObjectOfType<InformationDisplay>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Target") || collisioned) return;

        collisioned = true;
        Vector3 collisionForce = collision.impulse / Time.fixedDeltaTime;

        float xForce = Mathf.Abs(collisionForce.x);
        float yForce = Mathf.Abs(collisionForce.y);
        float zForce = Mathf.Abs(collisionForce.z);

        float forceVectorMod = Mathf.Sqrt(Mathf.Pow(xForce, 2) + Mathf.Pow(yForce, 2) + Mathf.Pow(zForce, 2));

        statsUI.SetImpactForceUI(forceVectorMod);
        statsUI.LoadTableData();
        

        this.enabled = false;
    }
}
