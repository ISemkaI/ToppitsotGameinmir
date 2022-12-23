using UnityEngine.Events;

public interface IHealthable
{
    int Health { get; }

    void TakeDamage(float damage);

    UnityEvent DiedEvent { get; }

    UnityEvent DamageTakenEvent { get; }
}