using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritBase : MonoBehaviour
{
    [SerializeField] Spirit spirit;
    [SerializeField] PlayerController playerController = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Guider")
        {
            playerController = other.GetComponentInParent<PlayerController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Guider")
        {
            playerController = null;
        }
    }

   
}
