using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RayShooter : MonoBehaviour
{

    public Camera _cameramy;
    public PlayerCharacter playertargetofmyhyi;
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
      //      Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
      //      Ray ray = _camera.ScreenPointToRay(point);
      //      RaycastHit hit;
      //      if(Physics.Raycast(ray, out hit)){
       //         GameObject hitObject = hit.transform.gameObject;
      //          ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
      //          if (target != null){
      //              target.ReactToHit();
      //              playertargetofmyhyi.KillerChecker();
      //          }
      //          else if(hitObject.tag != "enemy" && hitObject.tag == "Wall"){
       //             StartCoroutine(SphereIndicator(hit.point));
       //         }
      //     }
            _fireball = Instantiate(fireballPrefab) as GameObject;
            _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1);
            _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
            _fireball.transform.rotation = transform.rotation;
            _fireball.transform.position = transform.TransformPoint(Vector3.up * 0.5f);
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos){
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }

    void OnGUI(){
        int size = 12;
        float posX = _cameramy.pixelWidth/2 - size/4;
        float posY = _cameramy.pixelHeight/2 - size/4;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

}
