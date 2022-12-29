using UnityEngine;
using UnityEngine.Events;

// Утилитарный класс для проброса события триггера в класс машины состояния
// Класс должен лежать на врагах
[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class PhysicsEventAdapter : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent<Collider> TriggerEnterEvent;

    [HideInInspector]
    public UnityEvent<Collision> CollisionEnterEvent;

    private void OnTriggerEnter(Collider other) 
        => TriggerEnterEvent?.Invoke(other);

    private void OnCollisionEnter(Collision collision)
        => CollisionEnterEvent?.Invoke(collision);

}