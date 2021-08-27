using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int currentDamage;
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;

    int[] points = { 1, 2, 3, 4, 6 };

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SetRandomDamage();
        SetSpriteCannon();
    }

    void SetRandomDamage()
    {
        currentDamage = points[Random.Range(0, points.Length)];
    }

    public int GetDamage()
    {
        return currentDamage;
    }

    void SetSpriteCannon()
    {
        if (currentDamage != 6) spriteRenderer.sprite = sprites[currentDamage - 1];
        else spriteRenderer.sprite = sprites[4];
    }

    // Update is called once per frame
    void Update()
    {

    }

    
}
