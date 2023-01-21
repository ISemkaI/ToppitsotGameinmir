using TMPro;
using UnityEngine;

public class GameManagerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _killCounts;

    public void UpdateKillCounts(int killCount)
        => _killCounts.text = killCount.ToString();
}