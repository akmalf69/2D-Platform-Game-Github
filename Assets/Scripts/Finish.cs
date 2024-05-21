using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    private void OnTriggerEnter2D(Collider2D finish) 
    {
        if(finish.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    
}
