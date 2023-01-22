using UnityEditor;
using UnityEngine;

public class EnemyEmptyState : IState
{
    private readonly Transform _enemy;

    public EnemyEmptyState(Transform enemy)
    {
        _enemy = enemy;
    }

    public void Enter()
    {
        GameObject.Destroy(_enemy.gameObject);
    }

    public void Exit()
    {
    }
}