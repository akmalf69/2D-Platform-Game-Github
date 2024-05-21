using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{
    [SerializeField]
    Score scoreScript;

    private void OnTriggerEnter2D(Collider2D coin) 
    {
        if(coin.tag == "Player")
        {
            scoreScript.AddScore();
            Destroy(this.gameObject);
        }
    }




}
