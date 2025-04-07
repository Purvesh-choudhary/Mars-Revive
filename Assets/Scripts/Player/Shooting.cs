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
