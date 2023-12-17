using UnityEngine;

public class JetpackCollision : MonoBehaviour
{
    public Collider other;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DataHolder._jetpacksCount += 1;
            Destroy(gameObject);
        }
    }
}
