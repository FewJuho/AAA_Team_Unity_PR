using UnityEngine;

public class ShieldRotating : MonoBehaviour
{
    public Collider other;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DataHolder._shieldsCount += 1;
            Destroy(gameObject);
        }
    }
}
