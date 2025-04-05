using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMid : AlienBase
{
    public GameObject projectilePrefab;
    public Transform firePoint;

    protected override void Attack()
    {
        Debug.Log("Mid alien shoots!");
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = firePoint.forward * 10f;
    }
}

