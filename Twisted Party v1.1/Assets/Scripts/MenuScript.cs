using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject canvas;
    public Image image;
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public int slides = 0;

    void Start()
    {
        canvas.SetActive(false);
    }
    void Update()
    {
        if (slides == 1)
        {
            image.sprite = two;
        } else if (slides == 2)
        {
            image.sprite = three;
        } else if (slides == 3)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void SlidesPlusOne()
    {
        slides += 1;
    }
    public void Play()
    {
        canvas.SetActive(true);
    }
    public void Replay()
    {
        Application.Quit();
    }
}
