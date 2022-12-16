using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class Levelsbutton : MonoBehaviour
{

    public Button _LevelOne;

    void Start(){
        _LevelOne.onClick.AddListener(delegate{ LevelOne(); });
    }

    void LevelOne(){
        SceneManager.LoadScene(1);    
    }
    
}
