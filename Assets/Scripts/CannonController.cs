using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public Camera mainCamera;

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 targetPos = hit.point;
            Vector3 lookDir = targetPos - transform.position;
            lookDir.y = 0f; // Only rotate horizontally
            if (lookDir != Vector3.zero)
            {
                Quaternion rot = Quaternion.LookRotation(lookDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 10f);
            }
        }
    }
}
