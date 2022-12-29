using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    public float obstacleRange = 5.0f;

    private GameObject _fireball;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        
        if(Physics.SphereCast(ray, 0.5f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if(hitObject.GetComponent<Healthable>()){
                if(_fireball == null){
                    _fireball = Instantiate(fireballPrefab) as GameObject;
                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                    _fireball.transform.position = transform.TransformPoint(Vector3.up * 1.0f);
                }
            }
            else if(hit.distance < obstacleRange && hit.collider.tag == "Wall"){
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }

}
