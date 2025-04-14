using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMid : AlienBase
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootDelayTimer = 1f , bulletSpeed = 50f;
    

    protected override void Attack()
    {
        Debug.Log("Mid alien shoots!");
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        StartCoroutine(DelayedShoot(shootDelayTimer));
 
    }

    private IEnumerator DelayedShoot(float shootDelayTimer)
    {
        yield return new WaitForSeconds(shootDelayTimer); 

        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = firePoint.forward * bulletSpeed;
    }   

}

