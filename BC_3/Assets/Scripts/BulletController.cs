using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    GameObject shooting;

    [SerializeField]
    int speed;

    GameObject bullet;
    Shooting cannon;

    void Start()
    {
        bullet = Instantiate(shooting, transform.position, transform.rotation) as GameObject;
        cannon = bullet.GetComponent<Shooting>();
        cannon.speed = speed; 
    }
    public void Fire()
    {
        if (bullet.activeSelf == false)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        if (bullet != null) cannon.DestroyProjectile();
    }
}
