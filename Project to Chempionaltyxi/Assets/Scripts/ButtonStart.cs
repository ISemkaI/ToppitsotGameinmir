using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonStart : MonoBehaviour
{
    public Button _buttonStart;
    public Button _buttonExit;
    
    private void Start()
    {
        _buttonStart.onClick.AddListener( () => StartGame() );
        _buttonExit.onClick.AddListener( () => ExitGame() ); 
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);    
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
