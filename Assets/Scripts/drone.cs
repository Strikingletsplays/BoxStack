using UnityEngine;
using System.Collections.Generic;

public class Drone : MonoBehaviour
{
    //Main gameScript
    private GameScript gameScript;

    //Time for the box to fall
    private float time;

    //For Box
    [SerializeField]
    private List<GameObject> boxes;
    [SerializeField]
    private Transform SpawnPoint;
    private GameObject box;
    private float speed;
    private int index;

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
        //Spawn random box
        index = Random.Range(0, boxes.Count);
        //Spawn sellected box
        box = Instantiate(boxes[index], SpawnPoint.position, Quaternion.identity);
        box.transform.parent = gameObject.transform;
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
                if (box)
                {
                    box.transform.parent = null;
                    box.GetComponent<Rigidbody2D>().simulated = true;
                }
               
            }
        }
    }
    void MoveDrone()
    {
        if (box && box.transform.parent != null)
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
