using UnityEngine;

public class Controller : MonoBehaviour
{
    private Health Health;
    private GameScript GameScript;
    private void Awake()
    {
        GameScript = GetComponent<GameScript>();
        Health = GetComponent<Health>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BOX"))
        {
            Health.decreaseHealth();
            GameScript.ScoreDecrease();
            Destroy(collision.gameObject);
        }
        if(collision.CompareTag("Player"))
        {
            //Death Canvas
            GameScript.GameOver();
        }
    }
}
