using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardProjectile : MonoBehaviour, IProjectile
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed = 10.0f;

    [SerializeField] private float _particleSystemSecondsLifetime;

    private Transform _particleDamage;
    private MeshRenderer _renderer;
    private bool _died;

    public float Damage => _damage;

    private void Start()
    {
        _particleDamage = transform.GetChild(0);
        _renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (_died == true)
            return;

        transform.Translate(0, 0, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _died = true;
        _renderer.enabled = false;

        GameObject.Instantiate(_particleDamage, transform.position, Quaternion.identity);

        _particleDamage.LookAt(-collision.impulse);
        _particleDamage.gameObject.SetActive(true);

        StartCoroutine(DestroyMeInSeconds(_particleSystemSecondsLifetime));
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
