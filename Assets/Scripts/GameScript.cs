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
    //Top Right (Score Goal)
    [SerializeField]
    private TextMeshProUGUI ScoreGoal;

    //Saving to file
    [SerializeField]
    private SaveScript saveScript;

    //Canvases
    [SerializeField]
    private Canvas DeathCanvas;
    [SerializeField]
    private Canvas Canvas;
    [SerializeField]
    private Canvas WonCanvas;

    //For Drones
    [SerializeField]
    private GameObject Drone;
    private float xSpawn;

    private void FixedUpdate()
    { 
        //if no drone is spawned..
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
        //Check if lvl-Goal is reached
        isLvlPassed();
    }
    void isLvlPassed()
    {
        if (Score >= float.Parse(ScoreGoal.text))
        {
            //Show won screan.
            WonCanvas.enabled = true;
            //hide canvas
            Canvas.enabled = false;

            Time.timeScale = 0;
            Debug.Log("You won!");
        }
    }
    void SpawnDrone()
    {
        //Swpan at loccation
        xSpawn = Random.Range(-10, -8);
        if (xSpawn < -9f)
        {
            xSpawn = Random.Range(8, 10);
        }

        Instantiate(Drone, new Vector3(xSpawn, 3.7f, 2), Quaternion.identity);
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
    public void Nextlvl()
    {
        int Nlvli = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(Nlvli);
        Time.timeScale = 1;
    }
}
