using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthable : MonoBehaviour
{
    public SceneUI UI;
    private Text hptext;
    public int health;

    private void Start(){
        health = UI.Health;
        hptext = UI.Hptext;
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.TryGetComponent(out Fireball fireball))
            health -= fireball.Damage;
/*        else if (collision.TryGetComponent(out ReactiveTarget reactive))
            health -= reactive.Damage;*/
        hptext.text = health.ToString();

        UI.Die();
    }
}
