using UnityEngine;

public class ShootController : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !DataHolder._stopMouseFollowing)
        {
            animator.SetTrigger("LeftClick");
        }
    }
}
