using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameManagerUI _gameManagerUI;
    [SerializeField] private Healthable _playerHealthable;

    [SerializeField] private List<Animator> _spaceShipsAnimators;

    private int _killsCount = 0;
    private bool _spawnerEnd;

    public void IncrementKills()
    {
        _killsCount++;
        _gameManagerUI.UpdateKillCounts(_killsCount);
    }

    public void Initialize()
    {
        _playerHealthable.DiedEvent.AddListener(OnDefeat);
        
        //WinEvent.AddListener(OnVictory);
    }

    private void OnDefeat()
    {
        _playerHealthable.DiedEvent.RemoveListener(OnDefeat);
        _gameManagerUI.ShowDefeatScreen();
    }

    private void SpawnerEnd()
    { }

    private void OnVictory()
    {
        foreach (var animatorShip in _spaceShipsAnimators)
            animatorShip.SetTrigger("End");

        _gameManagerUI.ShowVictoryScreen();
    }
}

