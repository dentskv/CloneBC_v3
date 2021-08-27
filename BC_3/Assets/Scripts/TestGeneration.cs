using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGeneration : MonoBehaviour
{
    [SerializeField]
    public Sprite[] sprites;
    [SerializeField]
    public GameObject gameObj;
    public SpriteRenderer spriteRenderer;

    public Health hp;
    int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        hp = gameObj.GetComponent<Health>();
        GetHP();
        SetSpriteBody();
        Debug.Log("TG hp: " + hp.currentHealth);

    }

    void GetHP()
    {
        currentHP = hp.currentHealth;
    }

    void SetSpriteBody()
    {
        if (currentHP == 2) spriteRenderer.sprite = sprites[0];
        if (currentHP == 4) spriteRenderer.sprite = sprites[1];
        if (currentHP == 6) spriteRenderer.sprite = sprites[2];
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0)
        {
            GetHP();
            SetSpriteBody();
        }
    }
}