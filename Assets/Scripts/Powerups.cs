using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    //Rotating powerup
    private float rotation;
    //Player gravity
    private CircleCollider2D gravity;

    private void Awake()
    {
        rotation = transform.rotation.y;
        gravity = GameObject.FindGameObjectWithTag("GravityCollider").GetComponent<CircleCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //Rotating Powerup
        rotation += 2;
        transform.rotation = Quaternion.Euler(transform.rotation.x, rotation, transform.rotation.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GameScript"))
        {
            //Destroy gameobject
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //if PowerUp = Magnet
            if(gameObject.tag == "Magnet")
            {
                //Enables circle-collider triger on player.
                gravity.enabled = true;
                StartCoroutine(disablePlayerGravity());
            }
            ///... more powerups go here


            //Disable power up after pickup
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
    IEnumerator disablePlayerGravity()
    {
        yield return new WaitForSeconds(4.0f);
        Debug.Log("Should unckeck");
        gravity.enabled = false;
        //Destroy gameObject
        Destroy(this.gameObject);
    }
}
