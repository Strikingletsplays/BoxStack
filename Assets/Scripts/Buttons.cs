using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Buttons : MonoBehaviour
{
    //Weight Particles
    private Transform Particles;
    //Players RigidBody
    [SerializeField]
    private Rigidbody2D PlayerRB;

    private void Start()
    {
        Particles = GameObject.FindGameObjectWithTag("PlayerParticles").GetComponent<Transform>();
    }
    public void Jump()
    {
        CrossPlatformInputManager.SetButtonDown("Jump");
        CrossPlatformInputManager.SetButtonUp("Jump");
    }
    public void WeightDown()
    {
        Particles.position = PlayerRB.transform.position;
        Particles.GetComponent<ParticleSystem>().Play();
        PlayerRB.gravityScale = 5f;
    }
    public void WeightUp()
    {
        PlayerRB.gravityScale = 3f;
        Particles.GetComponent<ParticleSystem>().Stop();
    }
}
