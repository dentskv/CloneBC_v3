using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("A_TankI")]

    public Transform aTankI;

    void Update()
    {
        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        if (aTankI != null)
        {
            transform.position = new Vector3(aTankI.position.x, aTankI.position.y, transform.position.z);
        }
    }
}
