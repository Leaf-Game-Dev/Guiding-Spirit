using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    [SerializeField] GameObject effect;
    [SerializeField] GameObject parent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // increment count in game manager
            GameManager.instance.Decrement();
            SoundManager.PlaySound(SoundManager.Sound.coin, 0.5f);
            // show effect
            var effect_ = Instantiate(effect, transform.position,Quaternion.identity);
            effect_.transform.localScale = Vector3.one*4;
            // destroy object
            parent.SetActive(false);
        }
    }

}
