// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Shooting : MonoBehaviour
// {
//     // public GameObject bulletPrefab;
//     // public Transform firePoint;
//     // public float bulletForce = 500f;

//     // void Update()
//     // {
//     //     if (Input.GetMouseButton(0)) // Left mouse button
//     //     {
//     //         GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
//     //         Rigidbody rb = bullet.GetComponent<Rigidbody>();
//     //         rb.AddForce(firePoint.forward * bulletForce);
//     //     }
//     // }



//     public float shootRange = 100f;
//     public float shootForce = 10f;
//     public Transform firePoint;
//     public LayerMask hitLayers;
//     public GameObject hitEffectPrefab;
//     public GameObject muzzleFlashPrefab;
//     public LineRenderer laserLine;

//     void Update()
//     {
//         if (Input.GetMouseButtonDown(0))
//         {
//             ShootRay();
//         }
//     }

//     void ShootRay()
//     {
//         // 🔥 Spawn muzzle flash
//         if (muzzleFlashPrefab != null)
//         {
//             GameObject muzzleVFX = Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation, firePoint);
//             Destroy(muzzleVFX, 2f);
//         }

//         Ray ray = new Ray(firePoint.position, firePoint.forward);
//         if (Physics.Raycast(ray, out RaycastHit hit, shootRange, hitLayers))
//         {
//             Debug.Log("Hit: " + hit.collider.name);

//             // ✨ Spawn hit spark
//             if (hitEffectPrefab != null)
//             {
//                 GameObject impactVFX = Instantiate(hitEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
//                 Destroy(impactVFX, 2f);
//             }

//             // 💥 Apply force
//             if (hit.rigidbody != null)
//             {
//                 hit.rigidbody.AddForce(-hit.normal * shootForce, ForceMode.Impulse);
//             }

//             // 🔦 Draw ray
//             if (laserLine != null)
//             {
//                 laserLine.SetPosition(0, firePoint.position);
//                 laserLine.SetPosition(1, hit.point);
//             }
//         }
//         else
//         {
//             // 🔦 No hit, draw full-length ray
//             if (laserLine != null)
//             {
//                 laserLine.SetPosition(0, firePoint.position);
//                 laserLine.SetPosition(1, firePoint.position + firePoint.forward * shootRange);
//             }
//         }
//     }
// }



using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float shootRange = 100f;
    public float shootForce = 10f;
    public float shootCooldownTimerMax = 10f;
    float shootCooldown =0f;
    bool canShoot = true;
    public Transform firePoint;
    public LayerMask hitLayers;
    public GameObject hitEffectPrefab;
    public GameObject muzzleFlashPrefab;
    public LineRenderer laserLine;

    public AudioClip shootSound;
    public AudioClip hitSound;
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(canShoot){
                ShootRay();
                canShoot = false;
            }
            shootCooldown += Time.deltaTime;
            if(shootCooldown>= shootCooldownTimerMax){
                shootCooldown = 0f;
                canShoot = true;
            }
        }else{
            shootCooldown = 0f;
            canShoot = true;

        }
    }

    void ShootRay()
    {
        // 🔊 Play shoot sound
        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound);
        }

        // 🔥 Muzzle Flash
        if (muzzleFlashPrefab != null)
        {
            GameObject muzzleVFX = Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation, firePoint);
            Destroy(muzzleVFX, 2f);
        }

        Ray ray = new Ray(firePoint.position, firePoint.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, shootRange, hitLayers))
        {
            // ✨ Hit Effect
            if (hitEffectPrefab != null)
            {
                GameObject impactVFX = Instantiate(hitEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactVFX, 2f);
            }

            // 💥 Play hit sound
            if (hitSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(hitSound);
            }

            // 💥 Apply force
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * shootForce, ForceMode.Impulse);
            }

            // 🔦 Ray line
            if (laserLine != null)
            {
                laserLine.SetPosition(0, firePoint.position);
                laserLine.SetPosition(1, hit.point);
            }
        }
        else
        {
            if (laserLine != null)
            {
                laserLine.SetPosition(0, firePoint.position);
                laserLine.SetPosition(1, firePoint.position + firePoint.forward * shootRange);
            }
        }
    }
}
