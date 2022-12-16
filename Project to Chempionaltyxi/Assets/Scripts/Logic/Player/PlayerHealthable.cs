using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthable : MonoBehaviour
{
    public Text hptext;
    public Text killertext;
    public int health = 100;
    public int kills = 0;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Fireball fireball))
            health -= fireball.Damage;
        else if (collision.TryGetComponent(out ReactiveTarget reactive))
            health -= reactive.Damage;

        hptext.text = health.ToString();

        Die();
    }

    private void Die()
    {
        if (health <= 0)
            SceneManager.LoadScene(0);
    }

    public void UpdateKillCount()
    {
        kills += 1;
        killertext.text = kills.ToString();
    }
}
