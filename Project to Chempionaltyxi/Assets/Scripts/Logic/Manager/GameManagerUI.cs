using TMPro;
using UnityEngine;

public class GameManagerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _killCounts;
    [SerializeField] private TextMeshProUGUI _hpPlayer;

    public void UpdateKillCounts(int killCount)
        => _killCounts.text = killCount.ToString();

    public void UpdateHp(int hp)
        => _hpPlayer.text = hp.ToString();
}