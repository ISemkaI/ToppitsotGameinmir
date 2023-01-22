using UnityEngine;

public interface IProjectile
{
    public float Damage { get; }

    public void InitBullet(Vector3 direction);
}