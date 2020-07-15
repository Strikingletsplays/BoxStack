using TMPro;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    //Score
    [SerializeField]
    private TextMeshProUGUI ScoreGUI;
    private float Score = 0;

    [SerializeField]
    private GameObject Drone;

    private float xSpawn;
    void Update()
    {
        if (!(GameObject.FindGameObjectWithTag("Drone")))
        {
            SpawnDrone();
        }

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

        Instantiate(Drone, new Vector3(xSpawn, 3.2f, 0), Quaternion.identity);
    }
}
