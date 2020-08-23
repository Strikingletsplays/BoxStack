using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Buttons : MonoBehaviour
{
    //Weight Particles
    [SerializeField]
    private Transform Particles;
    //Players RigidBody
    [SerializeField]
    private Rigidbody2D PlayerRB;
    //Weight down particles
    private Transform PlayerParticles;

    //Weight
    private bool Weight = false;

    private void FixedUpdate()
    {
        //Only move particles to player when button is pressed
        if (Weight)
        {
            Particles.position = PlayerRB.transform.position;
        }
    }
    public void Jump()
    {
        CrossPlatformInputManager.SetButtonDown("Jump");
        CrossPlatformInputManager.SetButtonUp("Jump");
    }
    public void WeightDown()
    {
        Weight = true;
        PlayerParticles = Instantiate(Particles, new Vector3(PlayerRB.transform.position.x, PlayerRB.transform.position.y, PlayerRB.transform.position.z), Quaternion.Euler(new Vector3(90,0,0)));
        PlayerParticles.GetComponent<ParticleSystem>().Play();
        PlayerRB.gravityScale = 5f;
    }
    public void WeightUp()
    {
        Weight = false;
        PlayerRB.gravityScale = 3f;
        PlayerParticles.GetComponent<ParticleSystem>().Stop();
        Destroy(PlayerParticles.gameObject, 5);
    }
}
