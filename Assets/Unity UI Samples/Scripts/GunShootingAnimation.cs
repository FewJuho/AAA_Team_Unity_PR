using UnityEngine;

public class ShootController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rigidbody;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !DataHolder._stopMouseFollowing)
        {
            animator.SetTrigger("LeftClick");
        }

        if (rigidbody.velocity.sqrMagnitude < 0.1)
        {
            animator.ResetTrigger("MoveTrigger");
        } 
        else
        {
            animator.SetTrigger("MoveTrigger");
        }
    }
}
