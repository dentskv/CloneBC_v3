using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chance : MonoBehaviour
{
    public int currentChance;
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;

    int[] points = { 1, 2, 3 };

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SetRandomChance();
        SetSpriteTower();
    }

    void SetRandomChance()
    {
        currentChance = points[Random.Range(0, points.Length)];
    }

    void SetSpriteTower()
    {
        if (currentChance == 1) spriteRenderer.sprite = sprites[0]; //to do: damage, currentHP, chance вли€ют на каждый спрайт 
        if (currentChance == 2) spriteRenderer.sprite = sprites[1];
        if (currentChance == 3) spriteRenderer.sprite = sprites[2];
    }

    // Update is called once per frame
    void Update()
    {

    }


}