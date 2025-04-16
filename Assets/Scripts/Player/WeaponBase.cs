using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public float shootRange = 100f;
    public float shootForce = 10f;
    public float shootCooldownTimerMax = 1f;

    protected float shootCooldown = 0f;
    protected bool canShoot = true;

    public Transform firePoint;
    public LayerMask hitLayers;
    public GameObject hitEffectPrefab, hitEffectNormalPrefab, muzzleFlashPrefab;
    public LineRenderer laserLine;

    public AudioClip shootSound;
    public AudioClip hitSound;
    public AudioSource audioSource;

    public bool enableAiming = true;
    public Transform cannonHead; 
    
    protected virtual void Update()
    {
        HandleCooldown();

        if (enableAiming)
        {
            AimTowardCursor();
        }

        if (Input.GetMouseButton(0) && canShoot)
        {
            Shoot();
            canShoot = false;
        }
    }


    protected void HandleCooldown()
    {
        if (!canShoot)
        {
            shootCooldown += Time.deltaTime;
            if (shootCooldown >= shootCooldownTimerMax)
            {
                shootCooldown = 0f;
                canShoot = true;
            }
        }
    }

    protected void AimTowardCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 200f))
        {
            Vector3 target = hit.point;
            target.y = transform.position.y; // Only rotate on Y-axis
            transform.LookAt(target);
        }
        else
        {
            // Aim in camera direction if nothing is hit (e.g., sky)
            Vector3 direction = ray.direction;
            direction.y = 0f; // keep only horizontal
            if (direction != Vector3.zero)
            {
                Quaternion lookRot = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, 360f * Time.deltaTime);
            }
        }
    }


    // protected void AimTowardCursor()
    // {
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     if (Physics.Raycast(ray, out RaycastHit hit, 200f))
    //     {
    //         Vector3 target = hit.point;
    //         target.y = transform.position.y; // Only rotate on Y-axis
    //         transform.LookAt(target);
    //     }
    //     else
    //     {
    //         // Aim in camera direction if nothing is hit (e.g., sky)
    //         Vector3 direction = ray.direction;
    //         direction.y = 0f; // keep only horizontal
    //         if (direction != Vector3.zero)
    //         {
    //             Quaternion lookRot = Quaternion.LookRotation(direction);
    //             transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, 360f * Time.deltaTime);
    //         }
    //     }
    // }

    protected abstract void Shoot();
}
