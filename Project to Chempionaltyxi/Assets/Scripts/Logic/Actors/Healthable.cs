using UnityEngine.Events;
using UnityEngine;
using System;

public class Healthable : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private bool _updateUIText;

    public float Health => _health;

    [HideInInspector]
    public UnityEvent DiedEvent;

    [HideInInspector]
    public UnityEvent<float> DamageTakenEvent;

    private PhysicsEventAdapter _physicsEventer;
    private SceneUI _sceneUI;

    private void Awake()
    {
        if (TryGetComponent(out _physicsEventer) == false)
            _physicsEventer = gameObject.AddComponent<PhysicsEventAdapter>(); 

        _physicsEventer.CollisionEnterEvent.AddListener(CheckCollisionWithProjectile);

        if (_updateUIText == true)
            _sceneUI = GameObject.FindObjectOfType<SceneUI>();
    }

    public void TakeDamage(float damage)
    {
        float actualDamage = _health;
        _health = Mathf.Clamp(_health - damage, 0f, _health);
        actualDamage -= _health;

        if (_updateUIText == true && _sceneUI != null)
            _sceneUI.UpdateHealth(_health);
        
        DamageTakenEvent?.Invoke(actualDamage);

        if (Mathf.Approximately(_health, 0f))
            Die();
    }

    private void Die()
    {
        UnsubscribeEvents();
        DiedEvent?.Invoke();

        // За фактическую смерть объекта отвечает State-Machine
    }

    private void UnsubscribeEvents() 
        => _physicsEventer.CollisionEnterEvent.RemoveListener(CheckCollisionWithProjectile);

    private void CheckCollisionWithProjectile(Collision other)
    {
        if (other.gameObject.TryGetComponent(out IProjectile projectile))
            TakeDamage(projectile.Damage);
    }

}
