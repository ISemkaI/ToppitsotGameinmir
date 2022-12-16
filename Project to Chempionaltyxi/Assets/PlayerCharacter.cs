using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{
    public Text heatext;
    public Text killertext;
    public int health = 100;
    public int kills = 0;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Fireball"))
        {
            health -= 5;
        }
        else if (collision.CompareTag("enemy1"))
        {
            health -= 10;
        }


    }

    public void KillerChecker(){
        kills += 1;
        killertext.text = kills.ToString();
    }

    void Update(){
        if (health <= 0){
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        heatext.text = health.ToString();
    }
    
}
