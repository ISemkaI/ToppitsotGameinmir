using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneUI : MonoBehaviour
{
    [Header("Настройки UI")]
    public GameObject Canvas;
    public GameObject WinImage;
    public GameObject DieImage;
    public GameObject UIInterface;

    public Text Hptext;
    public Text Killertext;

    public int KillsToWin = 0;

    private int _kills = 0;

    public void UpdateKillCount()
    {
        _kills += 1;
        Killertext.text = _kills.ToString();
        WinCheck();
    }

    public void UpdateHealth(float health) 
        => Hptext.text = Mathf.Floor(health).ToString();

    private IEnumerator Win()
    {
        WinImage.SetActive(true);
        UIInterface.SetActive(false);

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(0);

    }

    public void DieAnimationUI()
    {
        StartCoroutine(DieUI());
    }

    private IEnumerator DieUI(){
        DieImage.SetActive(true);
        UIInterface.SetActive(false);

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(0);
    }


    private void WinCheck()
    {
        if(KillsToWin == _kills)
            StartCoroutine(Win());
        
    }
}
