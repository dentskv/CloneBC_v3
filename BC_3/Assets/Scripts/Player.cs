using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : Movement
{
    int currentSpeed, temp;
    float h, v;
    Rigidbody2D rb2d;
    BulletController bulletController;
    public Health playerHP;
    
    int[] points = { 5, 4, 3 };

    void Start()
    {
        bulletController = GetComponentInChildren<BulletController>();
        rb2d = GetComponent<Rigidbody2D>();
        playerHP = gameObject.GetComponent<Health>();
        currentSpeed = playerHP.currentHealth/2;
        base.SetSpeed(points[currentSpeed - 1]);
        Debug.Log("speed" + currentSpeed);
    }

    private void FixedUpdate()
    {
        if (h != 0 && !isMoving) StartCoroutine(MoveHorizontal(h, rb2d));
        else if (v != 0 && !isMoving) StartCoroutine(MoveVertical(v, rb2d));
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletController.Fire();
        }
    }
}
