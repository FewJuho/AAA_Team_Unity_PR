using UnityEngine;

public class BonusAnimation: MonoBehaviour
{
    public Animator animator;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !DataHolder._stopMouseFollowing)
        {
            animator.SetTrigger("HealTrigger");
        }

    }
}
