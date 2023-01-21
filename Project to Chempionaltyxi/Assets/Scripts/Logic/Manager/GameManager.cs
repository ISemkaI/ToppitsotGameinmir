using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameManagerUI _gameManagerUI;

    private int _killsCount = 0;

    public void IncrementKills()
    {
        _killsCount++;
        _gameManagerUI.UpdateKillCounts(_killsCount);
    }    
}

