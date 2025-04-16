using UnityEngine;

public class CannonWeapon : WeaponBase
{

    public float coneRadius = 1.5f; // radius for the cone/sphere cast
    public int damagePerShoot = 20;
    protected override void Shoot()
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
        //if (Physics.Raycast(ray, out RaycastHit hit, shootRange, hitLayers))
        if (Physics.SphereCast(ray, coneRadius, out RaycastHit hit, shootRange, hitLayers))
        {
            // ✨ Hit Effect
            if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Aliens")){
                if (hitEffectPrefab != null)
                {
                    GameObject impactVFX = Instantiate(hitEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impactVFX, 2f);
                }
            }else{
                if (hitEffectNormalPrefab != null)
                {
                    GameObject impactVFX = Instantiate(hitEffectNormalPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impactVFX, 2f);
                }
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

            // 🎯 Damage enemy
            AlienBase alien = hit.collider.GetComponent<AlienBase>();
            if (alien != null)
            {
                alien.TakeDamage(damagePerShoot); // Cannon does 20 dmg
            }

            // 🎯 Damage base
            BaseHealth baseHealth = hit.collider.GetComponent<BaseHealth>();
            if (baseHealth != null)
            {
                baseHealth.TakeDamage(damagePerShoot); // Same damage as alien
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
