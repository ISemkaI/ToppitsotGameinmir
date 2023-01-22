using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameManagerUI _gameManagerUI;
    [SerializeField] private Healthable _playerHealthable;

    private int _killsCount = 0;

    public void IncrementKills()
    {
        _killsCount++;
        _gameManagerUI.UpdateKillCounts(_killsCount);
    }

    public void Initialize()
    {
        _playerHealthable.DiedEvent.AddListener(OnLose);
    }

    private void OnLose()
    {
        _playerHealthable.DiedEvent.RemoveListener(OnLose);

        Debug.Log("Lose event");
    }
}

