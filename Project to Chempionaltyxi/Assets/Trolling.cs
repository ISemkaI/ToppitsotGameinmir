using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trolling : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject screamer;

    void OnTriggerEnter(Collider col) {
        GameObject trig = col.gameObject;
        if(trig.tag == "Player"){
	        Scream.Play();
            screamer.SetActive(true);
        }
    }
    
    void OnTriggerExit(Collider col) {
        GameObject trig = col.gameObject;
        if(trig.tag == "Player"){
            screamer.SetActive(false);
        }
    }






}
