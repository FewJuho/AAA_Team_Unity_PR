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

        if (rigidbody.velocity.sqrMagnitude < 0.01)
        {
            animator.ResetTrigger("MoveTrigger2");
        }
        else
        {
            animator.SetTrigger("MoveTrigger2");
        }
    }
}
