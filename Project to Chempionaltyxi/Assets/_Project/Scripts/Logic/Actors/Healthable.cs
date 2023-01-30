using UnityEngine.Events;
using UnityEngine;
using System;

public class Healthable : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private bool _updateUIText;
    [SerializeField] private bool _needPhysicsAdapter = true;
    [SerializeField] private bool _needParticleDeath = true;

    [SerializeField] private GameObject _particleDeath;

    public float Health => _health;

    [HideInInspector]
    public UnityEvent DiedEvent;

    [HideInInspector]
    public UnityEvent<float> DamageTakenEvent;

    // Это роль projectile проверять коллизии
    private PhysicsEventAdapter _physicsEventer;
    private GameManagerUI _gameManagerUI;

    private bool _isAlive = true;

    private void Awake()
    {
        if (_needPhysicsAdapter == true)
            if (TryGetComponent(out _physicsEventer) == false)
                _physicsEventer = gameObject.AddComponent<PhysicsEventAdapter>(); 

        //_physicsEventer.CollisionEnterEvent.AddListener(CheckCollisionWithProjectile);

        if (_updateUIText == true)
            _gameManagerUI = GameObject.FindObjectOfType<GameManagerUI>();
    }

    public void TakeDamage(float damage)
    {
        float actualDamage = _health;
        _health = Mathf.Clamp(_health - damage, 0f, _health);
        actualDamage -= _health;

        if (_updateUIText == true && _gameManagerUI != null)
            _gameManagerUI.UpdateHp((int)_health);
        
        DamageTakenEvent?.Invoke(actualDamage);

        if (Mathf.Approximately(_health, 0f) == true)
            Die();
    }

    private void Die()
    {
        if (_isAlive == false) 
            return;

        //UnsubscribeEvents();
        if (_needParticleDeath == true)
            _particleDeath.SetActive(true);

        _isAlive = false;
        DiedEvent?.Invoke();

        // За фактическую смерть врага отвечает State-Machine
        // За проигрыш игрока отвечает GameManager
    }

    /*private void UnsubscribeEvents() 
        => _physicsEventer.CollisionEnterEvent.RemoveListener(CheckCollisionWithProjectile);

    private void CheckCollisionWithProjectile(Collision other)
    {
        if (other.gameObject.TryGetComponent(out IProjectile projectile))
            TakeDamage(projectile.Damage);
    }*/

}
