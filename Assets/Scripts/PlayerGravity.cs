using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("BOX"))
        {
            //add force to the BOX towards player.
            Transform box = collision.GetComponent<Transform>();
            box.position = Vector2.MoveTowards(box.position, transform.position, 2 * Time.smoothDeltaTime);
        }
    }
}
