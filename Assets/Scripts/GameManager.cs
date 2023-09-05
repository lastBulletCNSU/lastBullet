using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public GameObject gameEndText;
    public GameObject gameNextText;
    public Text timeText;
    public Text recordText;

    private bool isGameover;
    public int stage;
    public float startTime;

    // Start is called before the first frame update
    void Start()
    {
        gameoverText.SetActive(false);
        gameEndText.SetActive(false);
        gameNextText.SetActive(false);
        isGameover = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            startTime -= Time.deltaTime;
            timeText.text = "Time : " + (int)startTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(stage);
            }
        }
        if ((int)startTime == 0)
        {
            startTime = 0;
            gameoverText.SetActive(false);
            gameEndText.SetActive(false);
            gameNextText.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(stage+1);
            }
        }
        if (stage == 3)
        {
            isGameover = true;
            gameoverText.SetActive(false);
            gameEndText.SetActive(true);
            gameNextText.SetActive(false);
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);


    }
}
