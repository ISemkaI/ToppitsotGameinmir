using UnityEngine;
using UnityEngine.Events;

// Утилитарный класс для проброса события триггера в класс машины состояния
// Класс должен лежать на врагах
[RequireComponent(typeof(Collider))]
public class PhysicsEventAdapter : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent<Collider> TriggerEnterEvent = new UnityEvent<Collider>();

    [HideInInspector]
    public UnityEvent<Collision> CollisionEnterEvent = new UnityEvent<Collision>();

    private void Awake()
    {
        if (TryGetComponent(out Rigidbody _) == false)
        {
            var rigidbody = gameObject.AddComponent<Rigidbody>();
            rigidbody.useGravity = false;
        }
    }

    private void OnTriggerEnter(Collider other) 
        => TriggerEnterEvent?.Invoke(other);

    private void OnCollisionEnter(Collision collision)
        => CollisionEnterEvent?.Invoke(collision);

}