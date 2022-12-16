using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public GameObject Player;
    public PlayerCharacter playertargetofmyhyi;

  //  public void ReactToHit(){
 //       StartCoroutine(Die());
  //  }

  //  private IEnumerator Die(){  
  //      Destroy(this.gameObject);
  //      yield return null;
   // }
   void OnTriggerEnter(Collider col){
        if(col.tag == "MyFireball"){
            playertargetofmyhyi.KillerChecker();
            Destroy(gameObject);
        }
   }
}
