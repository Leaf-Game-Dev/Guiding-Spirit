using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public Transform player, tamashi;
    bool canLook;
    public GameManager manager;
    public BoxCollider collider_;
    public GameObject visual;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canLook = true;
            manager.OnFinishLineReached();
            visual.SetActive(false);
            collider_.enabled = false;
        }
    }

    private void Update()
    {
        if (canLook)
        {
            player.LookAt(tamashi);
            tamashi.LookAt(player);
        }
    }
}
