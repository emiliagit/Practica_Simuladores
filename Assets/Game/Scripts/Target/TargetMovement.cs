using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float speed;
    public float desactivatePosition;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -desactivatePosition)
        {
            gameObject.SetActive(false);
        }
    }

    
}
