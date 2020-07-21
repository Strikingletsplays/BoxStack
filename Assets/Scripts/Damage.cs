using UnityEngine;
using UnityEngine.SceneManagement;


public class Damage : MonoBehaviour
{
    private Health Health;
    private void Awake()
    {
        Health = GameObject.FindGameObjectWithTag("GameScript").GetComponent<Health>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BOX"))
        {
            Health.decreaseHealth();
        }
        if(collision.CompareTag("Player"))
        {
            // end game/restart round
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
