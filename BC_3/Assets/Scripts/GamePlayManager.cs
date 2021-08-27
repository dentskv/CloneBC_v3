using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField]
    Image topCurtain, bottomCurtain, blackCurtain;
    [SerializeField]
    Text stageNumberText, gameOverText;
    void Start()
    {
        StartCoroutine(StartStage());
        gameOverText.enabled = false;
    }

    IEnumerator StartStage()
    {
        StartCoroutine(RevealStageNumber());
        yield return new WaitForSeconds(2);
        StartCoroutine(RevealTopStage());
        StartCoroutine(RevealBottomStage());
    }

    IEnumerator RevealStageNumber()
    {
        while (blackCurtain.rectTransform.localScale.y > 0)
        {
            blackCurtain.rectTransform.localScale = new Vector3(1, Mathf.Clamp(blackCurtain.rectTransform.localScale.y - Time.deltaTime, 0, 1), 1);
            yield return null;
        }
    }

    IEnumerator RevealTopStage()
    {
        stageNumberText.enabled = false;
        while (topCurtain.rectTransform.position.y < 2650)
        {
            topCurtain.rectTransform.Translate(new Vector3(0, 500 * Time.deltaTime, 0));
            yield return null;
        }
    }

    public IEnumerator GameOver()
    {
        while (gameOverText.rectTransform.localPosition.y < -60)
        {
            gameOverText.rectTransform.localPosition = new Vector3(gameOverText.rectTransform.localPosition.x, gameOverText.rectTransform.localPosition.y + 120f * Time.deltaTime, gameOverText.rectTransform.localPosition.z);
            yield return null;
        }
    }

    IEnumerator RevealBottomStage()
    {
        while (bottomCurtain.rectTransform.position.y > -400)
        {
            bottomCurtain.rectTransform.Translate(new Vector3(0, -500 * Time.deltaTime, 0));
            yield return null;
        }
    }

    public IEnumerator FinalStage()
    {
        StartCoroutine(RevealStageNumber());
        yield return null;
    }

    public IEnumerator PlayerDeath()
    {
        gameOverText.enabled = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
