using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Buttons : MonoBehaviour
{
    //Weight Particles
    private Transform Particles;
    //Players RigidBody
    [SerializeField]
    private Rigidbody2D PlayerRB;

    //Weight
    private bool Weight = false;

    private void Start()
    {
        Particles = GameObject.FindGameObjectWithTag("PlayerParticles").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
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
        Particles.GetComponent<ParticleSystem>().Play();
        PlayerRB.gravityScale = 5f;
    }
    public void WeightUp()
    {
        Weight = false;
        PlayerRB.gravityScale = 3f;
        Particles.GetComponent<ParticleSystem>().Stop();
    }
}
