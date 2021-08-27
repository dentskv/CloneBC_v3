using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    GameObject tank;
    [SerializeField]
    bool isPlayer;
    [SerializeField]
    GameObject tankI;
    int i = 0;

    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        anim.Play();
    }

    public void StartSpawning()
    {
        tank = Instantiate(tankI, transform.position, transform.rotation);
        i++;
    }

    public void SpawnNewTank()
    {
        //if (tank != null) tank.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayer && tank == null && i < 15)
        {
            anim.Play();
        }
        else anim.Stop();
    }
}
