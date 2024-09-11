using UnityEngine;

public class TriggerObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null && player.IsDaed == false)
        {
            player.Die();
        }
    }
}