using UnityEngine;

public class InfShootingAnim : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rigidbody;
    void Update()
    {
        if (Input.GetMouseButton(0) && !DataHolder._stopMouseFollowing)
        {
            animator.SetTrigger("LeftClick");
        }
    }
}
