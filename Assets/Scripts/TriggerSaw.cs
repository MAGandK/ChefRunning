using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSaw : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            //player.Damage();
        }
    }
}
