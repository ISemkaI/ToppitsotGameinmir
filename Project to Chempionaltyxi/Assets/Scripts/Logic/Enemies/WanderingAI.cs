using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    //public PlayerCharacter playertargetofmyhyi;
    
    [SerializeField] private GameObject _fireballPrefab;

    public float ObstacleRange = 5.0f;

    private GameObject _fireball;
    private float _speed = 3.0f;


    private void Update()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.SphereCast(ray, 0.5f, out RaycastHit hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            if (hitObject.GetComponent<PlayerHealthable>())
            {
                if(_fireball == null)
                {
                    _fireball = Instantiate(_fireballPrefab) as GameObject;

                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                    _fireball.transform.position = transform.TransformPoint(Vector3.up * 1.0f);
                }
            }
            else if(hit.distance < ObstacleRange && hit.collider.tag == "Wall"){
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
        
    }
}
