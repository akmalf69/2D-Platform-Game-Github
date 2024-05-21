using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Lifes : MonoBehaviour
{
    TextMeshProUGUI lifesText;

    [SerializeField]
    bool initLife = false;

    [SerializeField]
    GameObject GameOver;

    void Start()
    {
        lifesText = GetComponent<TextMeshProUGUI>();
    }

    void ResetLifes()
    {
        PlayerPrefs.SetInt("Lifes", 3);
    }

    public void ReduceLifes()
    {
        int lifes = PlayerPrefs.GetInt("Lifes");
        lifes = lifes -1;
        PlayerPrefs.SetInt("Lifes", lifes);

        if(lifes > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            //Game Over Screen
            GameOver.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void Retry()
    {
        Time.timeScale = 1;
        ResetLifes();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
    }

    public void Quit()
    {
        SceneManager.LoadScene("StartMenu");
    }

    void Update()
    {
        if(initLife == true)
        {
            ResetLifes();
            initLife = false;
        }

        lifesText.text = "Lifes = " + PlayerPrefs.GetInt("Lifes");
    }
}
