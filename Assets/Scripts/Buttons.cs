using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Buttons : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D PlayerRB;
    public void Jump()
    {
        CrossPlatformInputManager.SetButtonDown("Jump");
        CrossPlatformInputManager.SetButtonUp("Jump");
    }
    public void WeightDown()
    {
        PlayerRB.gravityScale = 5f;
    }
    public void WeightUp()
    {
        PlayerRB.gravityScale = 3f;
    }
}
