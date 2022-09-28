using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;

        SpiritStones = SpiritParent.childCount;
        SpiritCount.text = "x "+SpiritStones.ToString();
    }

    [SerializeField] TMPro.TMP_Text SpiritCount;
    [SerializeField] Transform SpiritParent;

    int SpiritStones;

    public void Decrement()
    {
        if (SpiritStones > 0)
        {
            SpiritStones--;
            SpiritCount.text = "x " + SpiritStones.ToString();
        }
        else
        {
            // game Finished
        }
    }

}
