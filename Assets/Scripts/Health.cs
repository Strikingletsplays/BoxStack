using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private GameScript GameScript;

    [SerializeField]
    private Image heart1, heart2, heart3;
    [SerializeField]
    private Sprite fallenBox;
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
        }
        else if (PHealth == 2)
        {
            heart3.sprite = fallenBox;
        }
        else if (PHealth == 1)
        {
            heart2.sprite = fallenBox;
        }
        else if (PHealth <= 0)
        {
            heart1.sprite = fallenBox;

            //Scene scene = SceneManager.GetActiveScene();
            GameScript.GameOver();
        }
        
    }
    private void Awake()
    {
        GameScript = GetComponent<GameScript>();
    }
}
