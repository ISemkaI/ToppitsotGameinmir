using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Healthable))]
public class BarrelExplosion : MonoBehaviour
{
    [SerializeField] private Vector3 _explosionBounds;
    [SerializeField] private LayerMask _explosionLayer;

    private MeshRenderer _meshRenderer;
    private Healthable _healthable;

    private void Awake()
    {
        _healthable = GetComponent<Healthable>();
        _meshRenderer = GetComponent<MeshRenderer>();

        _healthable.DiedEvent.AddListener(Explode);
    }

    private void Explode()
    {
        _meshRenderer.enabled = false;

        var raycastHits = Physics.BoxCastAll(transform.position, _explosionBounds, Vector3.up, 
            Quaternion.identity, 100f, _explosionLayer.value);

        foreach(var hit in raycastHits)
            if (hit.transform.TryGetComponent<Healthable>(out Healthable enemyHealthable))
                enemyHealthable.TakeDamage(100f);

        StartCoroutine(DeathDelayed());
    }

    IEnumerator DeathDelayed()
    {
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
