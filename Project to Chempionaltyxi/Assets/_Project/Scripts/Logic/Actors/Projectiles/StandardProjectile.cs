using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardProjectile : MonoBehaviour, IProjectile
{
    [SerializeField] private int _damage;
    [SerializeField] private float speed = 10.0f;

    [SerializeField] private GameObject _particleDamage;

    public float Damage => _damage;

    private void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Instantiate(_particleDamage, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
