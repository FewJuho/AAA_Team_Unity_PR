using UnityEngine;

public class AdrenalineCollision : MonoBehaviour
{
    public Collider other;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DataHolder._damageUpsCount += 1;
            Destroy(gameObject);
        }
    }
}
