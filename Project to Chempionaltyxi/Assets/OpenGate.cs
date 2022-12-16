using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{

    public GameObject grib1;
    public GameObject grib2;
    public GameObject grib3;
    public GameObject grib4;

    void OnTriggerEnter(Collider col){
        GameObject trig = col.gameObject;
        if(trig.tag == "Player"){
            grib1.SetActive(false);
            grib2.SetActive(false);
            grib3.SetActive(false);
            grib4.SetActive(false);
        }

    }
    void OnTriggerStay(Collider col){
        GameObject trig = col.gameObject;
        if(trig.tag == "Player"){
            grib1.SetActive(false);
            grib2.SetActive(false);
            grib3.SetActive(false);
            grib4.SetActive(false);
        }

    }
    void OnTriggerExit(Collider col){
        GameObject trig = col.gameObject;
        if(trig.tag == "Player"){
            grib1.SetActive(true);
            grib2.SetActive(true);
            grib3.SetActive(true);
            grib4.SetActive(true);
        }
        
    }





}
