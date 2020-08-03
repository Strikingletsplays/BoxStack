using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    //Score
    [SerializeField]
    private TextMeshProUGUI ScoreGUI;
    private float Score = 0;
    [SerializeField]
    private TextMeshProUGUI currentScore;
    [SerializeField]
    private GameObject newHighScore;

    //Saving to file
    private SaveScript saveScript;
    

    //Canvases
    [SerializeField]
    private Canvas DeathCanvas;
    [SerializeField]
    private Canvas Canvas;

    //For Drones
    [SerializeField]
    private GameObject Drone;
    private float xSpawn;

    private void Awake()
    {
        saveScript = GetComponent<SaveScript>();
    }
    void Update()
    {
        if (!(GameObject.FindGameObjectWithTag("Drone")))
        {
            SpawnDrone();
        }

    }
    public float getScore()
    {
        return Score;
    }
    public void ScoreAdd()
    {
        Score++;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreGUI.text = Score.ToString();
    }
    void SpawnDrone()
    {
        //Swpan at loccation
        xSpawn = Random.Range(-10, -8);
        if (xSpawn < -9f)
        {
            xSpawn = Random.Range(8, 10);
        }

        Instantiate(Drone, new Vector3(xSpawn, 2.5f, 0), Quaternion.identity);
    }
    public void GameOver()
    {
        Canvas.enabled = false; 
        if (saveScript.LoadData()==null)    //First time playing
        {
            newHighScore.SetActive(true);
        }
        else if (Score > saveScript.LoadData().SavedScore)  
        {
            newHighScore.SetActive(true);
        }
        DeathCanvas.enabled = true;
        Time.timeScale = 0;
        saveScript.LoadData();
        currentScore.text = Score.ToString();
    }
    public void Restartlvl()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }
}
