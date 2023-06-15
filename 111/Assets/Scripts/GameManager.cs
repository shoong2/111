using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    //콤보
    public int combo = 0;
    public TMP_Text comboCount;


    //스코어
    public float score = 0;
    public TMP_Text scoreCount;
    Color initColor;

    //게임 끄기
    int ClickCount = 0;

    //클리어
    public float clearTime;
    public float curTime = 0;
    public Slider timer;

    //게임오버
    public GameObject gameOver;

    //게임클리어
    public GameObject gameClear;
    public TMP_Text scoreText;
    bool clear = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        initColor = comboCount.color;
        scoreCount.text = ((int)score).ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickCount++;
            if (!IsInvoking("DoubleClick"))
                Invoke("DoubleClick", 1.0f);

        }
        else if (ClickCount == 2)
        {
            CancelInvoke("DoubleClick");
            Application.Quit();
        }

        if (timer.value < 1)
        {
            curTime += Time.deltaTime;
            timer.value = curTime / clearTime;
        }
        else
        {
            if (!clear)
                GameClear();
        }

    }

    void DoubleClick()
    {
        ClickCount = 0;
    }

    public void ShowCombo()
    {
        if (combo != 0)
        {
            StartCoroutine(AddScore());
            StopCoroutine("FadeOut");
            StartCoroutine("FadeOut");

        }
    }

    IEnumerator FadeOut()
    {

        comboCount.gameObject.SetActive(true);
        comboCount.text = combo.ToString() + " COMBO";
        Color color = initColor;
        comboCount.color = color;
        float fadeDuration = 1f;

        while (color.a > 0)
        {
            color.a -= Time.deltaTime / fadeDuration;
            comboCount.color = color;

            yield return null;
        }

        comboCount.gameObject.SetActive(false);
    }

    IEnumerator AddScore()
    {
        Debug.Log("heydfsdafd");
        float a;
        float b = 0;
        if (combo == 0)
            a = 500;
        else
            a = 500 * combo;

        while (b < a)
        {
            score += Time.deltaTime * a;
            b += Time.deltaTime * a;
            scoreCount.text = ((int)score).ToString();
            yield return null;
        }
        Debug.Log(score);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
       
    }

    public void GameClear()
    {
        clear = true;
        gameClear.SetActive(true);
        scoreText.text = "SCORE: "+((int)score).ToString();
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
