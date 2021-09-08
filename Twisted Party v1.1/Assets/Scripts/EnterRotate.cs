using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterRotate : MonoBehaviour
{
    //objects
    public GameObject obj;
    public GameObject text;
    public Text keyText;
    public GameObject slider;
    public Slider timerSlider;

    //variables
    public bool playerOne;
    public bool removeable;
    public bool playerInRange;

    private string key = "Fire1";
    private string key2 = "Fire1";
    public int keyNumber;
    public float cleanScore;
    public float maxCleanScore = 5;
    public bool complete = false;
    bool doubleKey = false;

    public float rotation = 180f;


    void Start()
    {
        if (removeable == false)
        {
            obj.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        //text and slider invisible
        text.SetActive(false);
        slider.SetActive(false);
        //max cleanuptime
        timerSlider.maxValue = maxCleanScore;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        playerInRange = true;

        if (complete == false)
        {
            text.SetActive(true);
            slider.SetActive(true);
        }

        if (other.gameObject.tag == "player1")
        {
            playerOne = true;
        }
        else
        {
            playerOne = false;
        }
        RandomKeyDependingOnInt();
    }

    void FixedUpdate()
    {
        ScoreCalculation();
        WhatToDoWhenCompleted();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (complete == false)
        {
            playerInRange = false;
            text.SetActive(false);
            slider.SetActive(false);
        }
    }

    void ScoreCalculation()
    {
        if (Input.GetButton(key) && complete == false && playerInRange == true)
        {
            if (doubleKey == false)
            {
                cleanScore += 1f;
                Debug.Log("adding cleanScore");
                timerSlider.value = cleanScore;
            } 


            if (doubleKey == true)
            {
                if (Input.GetButton(key2))
                {
                    cleanScore += 1f;
                    Debug.Log("adding cleanScore");
                    timerSlider.value = cleanScore;
                }
            }
        }
        else
        {
            cleanScore = 0;
        }

        bool once = true;

        if (cleanScore > maxCleanScore)
        {
            complete = true;
            Debug.Log("completed");
            if (once == true)
            {
                GameObject Thing = GameObject.Find("General");
                General general = Thing.GetComponent<General>();
                general.score += 1;
                once = false;
            }
        }
    }

    void WhatToDoWhenCompleted()
    {
        if (complete == true && removeable == true)
        {
            obj.SetActive(false);
            text.SetActive(false);
            slider.SetActive(false);
        }
        else if (complete == true && removeable == false)
        {
            text.SetActive(true);
            slider.SetActive(false);
            keyText.GetComponent<Text>().text = "✓";
            keyText.GetComponent<Text>().color = Color.green;
            obj.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void RandomKeyDependingOnInt()
    {
        if (playerOne == true)
        {
            keyNumber = Random.Range(1, 9);
        } else
        {
            keyNumber = Random.Range(10, 15);
        }

        //Player one
        if (keyNumber == 1)
        {
            key = "y";
            keyText.GetComponent<Text>().text = "Y";
        }
        else if (keyNumber == 2)
        {
            key = "i";
            keyText.GetComponent<Text>().text = "I";
        }
        else if (keyNumber == 3)
        {
            key = "b";
            keyText.GetComponent<Text>().text = "B";
        }
        else if (keyNumber == 4)
        {
            key = "n";
            keyText.GetComponent<Text>().text = "N";
        }
        else if (keyNumber == 5)
        {
            key = "m";
            keyText.GetComponent<Text>().text = "M";
        }
        //doubles
        else if (keyNumber == 6)
        {
            doubleKey = true;
            key = "y";
            key2 = "m";
            keyText.GetComponent<Text>().text = "Y + M";
        }
        else if (keyNumber == 7)
        {
            doubleKey = true;
            key = "i";
            key2 = "b";
            keyText.GetComponent<Text>().text = "I + B";
        }
        else if (keyNumber == 8)
        {
            doubleKey = true;
            key = "b";
            key2 = "m";
            keyText.GetComponent<Text>().text = "B + M";
        }
        else if (keyNumber == 9)
        {
            doubleKey = true;
            key = "y";
            key2 = "i";
            keyText.GetComponent<Text>().text = "Y + I";
        }
        //Player 2
        if (keyNumber == 10)
        {
            key = "q";
            keyText.GetComponent<Text>().text = "Q";
        }
        if (keyNumber == 11)
        {
            key = "e";
            keyText.GetComponent<Text>().text = "E";
        }
        if (keyNumber == 12)
        {
            key = "z";
            keyText.GetComponent<Text>().text = "Z";
        }
        if (keyNumber == 13)
        {
            key = "x";
            keyText.GetComponent<Text>().text = "X";
        }

        if (keyNumber == 14)
        {
            key = "c";
            keyText.GetComponent<Text>().text = "C";
        }
        //doubles
        if (keyNumber == 15)
        {
            doubleKey = true;
            key = "q";
            key2 = "c";
            keyText.GetComponent<Text>().text = "Q + C";
        }
        if (keyNumber == 16)
        {
            doubleKey = true;
            key = "e";
            key2 = "z";
            keyText.GetComponent<Text>().text = "E + Z";
        }
        if (keyNumber == 17)
        {
            doubleKey = true;
            key = "z";
            key2 = "c";
            keyText.GetComponent<Text>().text = "Z + C";
        }
        if (keyNumber == 18)
        {
            doubleKey = true;
            key = "q";
            key2 = "e";
            keyText.GetComponent<Text>().text = "Q + E";
        }
    }
}
