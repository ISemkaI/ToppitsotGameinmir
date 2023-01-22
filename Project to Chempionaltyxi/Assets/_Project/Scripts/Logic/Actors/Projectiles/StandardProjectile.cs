using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardProjectile : MonoBehaviour, IProjectile
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed = 10.0f;

    [SerializeField] private float _particleSystemSecondsLifetime;

    //private Transform _particleDamage;
    private MeshRenderer _renderer;
    private Vector3 _direction;
    private bool _died;

    public float Damage => _damage;

    public void InitBullet(Vector3 direction) 
        => _direction = direction;

    private void Start()
    {
        //_particleDamage = transform.GetChild(0);
        _renderer = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        if (_died == true)
            return;

        transform.position += _speed * Time.fixedDeltaTime * _direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _died = true;
        _renderer.enabled = false;

        if (collision.gameObject.TryGetComponent<Healthable>(out Healthable healthable))
            healthable.TakeDamage(_damage);


        //GameObject.Instantiate(_particleDamage, transform.position, Quaternion.identity);

        //_particleDamage.LookAt(-collision.impulse);
        //_particleDamage.gameObject.SetActive(true);

        StartCoroutine(DestroyMeInSeconds(0f/*_particleSystemSecondsLifetime*/));
    }

    IEnumerator DestroyMeInSeconds(float seconds)
    {
        while (seconds > 0)
        {
            yield return null;
            seconds -= Time.deltaTime;
        }

        Destroy(gameObject);
    }
}
