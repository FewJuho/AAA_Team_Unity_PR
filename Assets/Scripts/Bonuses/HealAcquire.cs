using UnityEngine;

public class HealCollision : MonoBehaviour
{
    public Collider other;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DataHolder._healsCount += 1;
            Destroy(gameObject);
        }
    }
}
