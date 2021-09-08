using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class General : MonoBehaviour
{
    public Text cleanText;
    public Text timerText;
    public float gameTime;
    public bool stopTimer;
    public int score;
    public int total;
    private float time;
    bool done = false;

    void FixedUpdate()
    {
        if (done == false)
        {
            time = gameTime - Time.time;
        }

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        timerText.GetComponent<Text>().text = "Mom's back in " + textTime + "s";
        cleanText.GetComponent<Text>().text = score.ToString() + "/" + total.ToString() + " cleaned";

        if (score == total)
        {
            SceneManager.LoadScene(2);
            done = true;
        }

        if (time <= 0)
        {
            SceneManager.LoadScene(3);
            done = true;
        }
    }
}
