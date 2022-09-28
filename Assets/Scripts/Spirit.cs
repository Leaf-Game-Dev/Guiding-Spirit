using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    [SerializeField] GameObject effect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // increment count in game manager
            GameManager.instance.Decrement();
            SoundManager.PlaySound(SoundManager.Sound.coin, 0.5f);
            // show effect
            Instantiate(effect, transform.position,Quaternion.identity);
            // destroy object
            Destroy(transform.parent.gameObject);
        }
    }

}
