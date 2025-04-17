using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropUp : MonoBehaviour
{

    [SerializeField] Vector3 rotateDirection;
    [SerializeField] GameObject dropCollectedFX; 
 
    public enum Droptype{
        health,
        ammo,
        shield,
    }

    public Droptype dropType;
    public int dropQuantity;


    void Update()
    {
        transform.Rotate(rotateDirection * Time.deltaTime , Space.Self);
    }

    public void DropCollectFX()
    {
        Instantiate(dropCollectedFX,transform.position,Quaternion.identity);
    }
}
