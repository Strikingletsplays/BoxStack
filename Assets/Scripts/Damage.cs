using UnityEngine;
using UnityEngine.SceneManagement;


public class Damage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BOX"))
        {
            // Reduce helth
            Debug.Log("A box has fallen");
        }
        if(collision.CompareTag("Player"))
        {
            // end game/restart round
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
