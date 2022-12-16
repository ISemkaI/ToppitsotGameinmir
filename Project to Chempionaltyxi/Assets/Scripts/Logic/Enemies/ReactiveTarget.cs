using UnityEngine.Events;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public UnityAction EnemyDied;

    public int Damage;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Fireball _))
        {
            EnemyDied?.Invoke();
            Destroy(gameObject);
        }
   }
}
