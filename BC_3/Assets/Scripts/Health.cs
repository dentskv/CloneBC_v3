using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int currentHealth;
    private int sceneIndex;
    private int maxSceneIndex = 2;
    [SerializeField]
    Text gameOverText;

    GamePlayManager GPM;

    int[] points = { 2, 4, 6 };

    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex; 
        if (currentHealth == 0)
        {
            SetRandomHealth();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            SetRandomHealth();
        }
    }

    void SetRandomHealth()
    {
        currentHealth = points[Random.Range(0, points.Length)];
    }

    void SetBaseHealth()
    {
        currentHealth = 10;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void KillPlayer()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(true);
        ToDestroy();
        GPM = GameObject.Find("Canvas").GetComponent<GamePlayManager>();
        StartCoroutine(GPM.PlayerDeath());
    }

    public void ToDestroy()
    {
        Destroy(gameObject);
    }

    void Death()
    {
        if (gameObject.CompareTag("Player") || gameObject.CompareTag("Base"))
        {
            KillPlayer();
        }
        else if (gameObject.CompareTag("EnemyBase"))
        {
            if (sceneIndex == maxSceneIndex)
            {
                GPM = GameObject.Find("CanvasEnd").GetComponent<GamePlayManager>();
                StartCoroutine(GPM.FinalStage());
                SceneManager.LoadScene(0);
                Debug.Log("load0");
            }
            else
            {
                Debug.Log("sI = " + sceneIndex);
                if (sceneIndex < maxSceneIndex) sceneIndex++;
                SceneManager.LoadScene(sceneIndex);
                Debug.Log("same");
            }
                
        }
        else Destroy(gameObject);
    }
}
