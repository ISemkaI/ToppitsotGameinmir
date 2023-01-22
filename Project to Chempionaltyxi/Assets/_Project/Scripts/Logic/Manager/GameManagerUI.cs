using TMPro;
using UnityEngine;

public class GameManagerUI : MonoBehaviour
{
    [Header("HUD details")]
    [SerializeField] private TextMeshProUGUI _killCounts;
    [SerializeField] private TextMeshProUGUI _hpPlayer;

    [Header("End game screens")]
    [SerializeField] private Fader _faderDefeat;
    [SerializeField] private Fader _faderVictory;

    private void Awake()
    {
        // Прячем с начала игры оба экрана
        _faderDefeat.HideImmediately();
        _faderVictory.HideImmediately();
    }

    public void UpdateKillCounts(int killCount)
        => _killCounts.text = killCount.ToString();

    public void UpdateHp(int hp)
        => _hpPlayer.text = hp.ToString();

    public void ShowDefeatScreen() 
        => _faderDefeat.FadeOut();

    public void ShowVictoryScreen()
        => _faderVictory.FadeOut();

    public void HideDefeatScreen()
        => _faderDefeat.FadeIn();

    public void HideVictoryScreen() 
        => _faderVictory.FadeIn();
}