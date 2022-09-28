using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritGuider : MonoBehaviour
{
    public void PlayFootSound()
    {
        SoundManager.PlaySound(SoundManager.Sound.FootStep,transform.position ,.05f);
    }

    public void PlayWalkFootSound()
    {
        SoundManager.PlaySound(SoundManager.Sound.FootStep, transform.position, .01f);
    }
}
