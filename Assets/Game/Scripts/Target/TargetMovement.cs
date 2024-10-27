using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float minSpeed; 
    public float maxSpeed; 
    private float speed;
    public float desactivatePosition;

    void OnEnable()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -desactivatePosition)
        {
            gameObject.SetActive(false);
        }
    }

    
}
