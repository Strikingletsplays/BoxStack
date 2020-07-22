using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private GameScript GameScript;

    [SerializeField]
    private Image heart1, heart2, heart3;
    private int PHealth = 3;

    public void decreaseHealth()
    {
        PHealth -= 1;
        UpdateUI();
    }

    public void increaseHealth()
    {
        PHealth += 1;
        UpdateUI();
    }
    public void UpdateUI()
    {
        if (PHealth >= 3)
        {
            PHealth = 3;
            heart1.enabled = true;
            heart2.enabled = true;
            heart3.enabled = true;
        }
        else if (PHealth == 2)
        {
            heart1.enabled = true;
            heart2.enabled = true;
            heart3.enabled = false;
        }
        else if (PHealth == 1)
        {
            heart1.enabled = true;
            heart2.enabled = false;
            heart3.enabled = false;
        }
        else if (PHealth <= 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            heart1.enabled = false;
            heart2.enabled = false;
            heart3.enabled = false;
            GameScript.GameOver();
        }
        
    }
    private void Awake()
    {
        GameScript = GetComponent<GameScript>();
    }
}
