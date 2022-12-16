using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyprefab;
    private GameObject _enemy;

    // Update is called once per frame

    void Start(){
        
    }
    void Update()
    {
        if(_enemy == null){
            _enemy = Instantiate(enemyprefab) as GameObject;
            float posx = Random.Range(-5.83f, 11.1f);
            float posz = Random.Range(-85.27f, -112.11f);
            _enemy.transform.position = new Vector3(posx, 7, posz);
            float angle = Random.Range(0, 360);
            _enemy.SetActive(true);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}
