using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonStart : MonoBehaviour
{
    public Button _buttonStart;
    public Button _buttonExit;
    //public Button _buttonLevels;



    // Start is called before the first frame update
    void Start()
    {
        _buttonStart.onClick.AddListener(delegate{ StartGame(); });
        _buttonExit.onClick.AddListener(delegate{ ExitGame(); }); 
        //    _buttonLevels.onClick.AddListener(delegate{ LevelsGame(); }); 
    }

    // Update is called once per frame
    void StartGame()
    {
        SceneManager.LoadScene(1);    
    }
    void ExitGame(){
        Application.Quit();
    }
    //void LevelsGame(){
   //     SceneManager.LoadScene(2);
    //}
}
