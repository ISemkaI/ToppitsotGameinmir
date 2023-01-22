using UnityEngine;

public interface IShootable
{
    public float Cooldown { get; }

    void Shoot(Transform target);
}