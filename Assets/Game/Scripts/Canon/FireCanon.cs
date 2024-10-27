using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireCanon : MonoBehaviour
{
    public Slider powerSlider;

    [SerializeField] Rigidbody projectilePrefab;
    [SerializeField] Transform firePoint;

    private float attackSpeed = 1f;
    private float nextAttackTime;

   
    void Update()
    {
        if (Input.GetButtonDown("Jump") && Time.time >= nextAttackTime)
        {
            Fire();
            nextAttackTime = Time.time + 1f / attackSpeed;
        }
    }

    public void Fire()
    {
        Rigidbody projectileInstance = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectileInstance.AddForce(firePoint.forward * powerSlider.value, ForceMode.Impulse);
        Destroy(projectileInstance.gameObject, 5f);
    }
}
