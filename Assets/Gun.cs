using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public int maxAmmo = 50;
    public int currentAmmo;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && currentAmmo > 0)
        {
            Shoot();
        }

        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }

    private void Shoot()
    {
        currentAmmo--;

        GameObject newProjectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        Rigidbody projectileRb = newProjectile.GetComponent<Rigidbody>();

        projectileRb.velocity = firePoint.forward * projectileSpeed;

        Destroy(newProjectile, 5f);
    }

}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;

    public void Shoot()
    {
        GameObject newProjectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody projectileRb = newProjectile.GetComponent<Rigidbody>();

        projectileRb.velocity = firePoint.forward * projectileSpeed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Shoot();
        }
    }
}*/
