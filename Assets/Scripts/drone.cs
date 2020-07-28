using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Drone : MonoBehaviour
{
    //Main gameScript
    private GameScript gameScript;

    //Time for the box to fall
    private float time;

    //For Box
    [SerializeField]
    private Transform box;
    private float speed;

    //Box Drop Range
    [SerializeField]
    private float range;

    //Drone Direction
    private bool isGoingLeft = false;

    private void Awake()
    {
        gameScript = GameObject.FindGameObjectWithTag("GameScript").GetComponent<GameScript>();
        //Drone speed
        speed = Random.Range(4, 6);
        //Time to drop box
        time = Random.Range(3, 8);
        //Set Random range
        range = Random.Range(0.5F, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //Mone Drone
        MoveDrone();
        //Countdown to drop box
        time -= 1f * Time.deltaTime;
        DropBox();
    }
    void DropBox()
    {
        if (time <= 0)
        {
            //if above platform
            if (transform.position.x <= range && transform.position.x >= -range)
            {
                //Drop Box
                box.parent = null;
                box.GetComponent<Rigidbody2D>().simulated = true;
            }
        }
    }
    void MoveDrone()
    {
        if (box && box.parent != null)
        {
            //Move Right
            if (transform.position.x < 7 && !isGoingLeft)
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
            else if (transform.position.x > -7)
            {
                //Move left
                isGoingLeft = true;
                transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
            }
            else
            {
                isGoingLeft = false;
            }
        }
        //box droped
        else
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            if (transform.position.x > 11)
            {
                gameScript.ScoreAdd();
                Destroy(this.gameObject);
            }
        }

    }
}
