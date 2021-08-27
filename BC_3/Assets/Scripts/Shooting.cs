using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Shooting : MonoBehaviour
{
    bool toBeDestroyed = false;
    GameObject brickGameObject, steelGameObject;
    public Damage damageTank;

    Tilemap tilemap; 
    public int damage;
    public int speed = 1;
    Rigidbody2D rb2d;

    void Start()
    {
        try
        {
            rb2d = GetComponent<Rigidbody2D>();
            rb2d.velocity = transform.up * speed;
            brickGameObject = GameObject.FindGameObjectWithTag("Brick");
        }
        catch { Debug.Log("rd2d"); }
        GameObject gameObject = GameObject.Find("Cannon");
        damageTank = gameObject.GetComponent<Damage>();
        damage = damageTank.currentDamage;
    }

    void OnEnable()
    {
        if (rb2d != null)
        {
            rb2d.velocity = transform.up * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        rb2d.velocity = Vector2.zero;
        tilemap = collision.gameObject.GetComponent<Tilemap>();
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
        if (collision.gameObject == brickGameObject)
        {
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
            }
        }
        this.gameObject.SetActive(false);
    }

    void OnDisable()
    {
        if (toBeDestroyed)
        {
            Destroy(this.gameObject);
        }
    }

    public void DestroyProjectile()
    {
        if (gameObject.activeSelf == false)
        {
            Destroy(this.gameObject);
        }
        toBeDestroyed = true;
    }
}