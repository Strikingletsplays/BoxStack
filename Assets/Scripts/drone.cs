using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class drone : MonoBehaviour
{
    private GameScript gameScript;
    //Time for the box to fall
    private float time;

    [SerializeField]
    private Transform box;
    private float speed = 2;

    private bool isGoingLeft = false;

    private void Awake()
    {
        gameScript = GameObject.FindGameObjectWithTag("GameScript").GetComponent<GameScript>();
        speed = Random.Range(3, 8);
        time = Random.Range(3, 20);
    }

    // Update is called once per frame
    void Update()
    {
        time -= 1f * Time.deltaTime;
        if (time<= 0)
        {
            //if ontop of scale
            if(transform.position.x < 6 && transform.position.x > -6)
            {
                //Drop box
                box.parent = null;
                box.GetComponent<Rigidbody2D>().simulated = true;
            }
        }
        MoveDrone();
    }
    void MoveDrone()
    {
        //Move Right
        if (transform.position.x < 7 && box.parent != null && !isGoingLeft)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        else if (transform.position.x > -7 && box.parent != null)
        {
            //Move left
            isGoingLeft = true;
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        else if (box.parent == null)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            if (transform.position.x > 11)
            {
                gameScript.ScoreAdd();
                Destroy(this.gameObject);
            }
        }
        else
        {
            isGoingLeft = false;
        }
    }
}
