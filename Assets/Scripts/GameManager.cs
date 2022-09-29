using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public NPCConversation StartDialog,EndDialog;
    public PlayerController PlayerController;
    public GameObject StartCam,EndCam;
    public Animator tamashiPlayer;
    public GameObject Stone;
    public GameObject FinishLine;
    public SceneLoader sceneLoader;

    NPCConversation current;
    private void Start()
    {
        FinishLine.SetActive(false);
        ConversationManager.OnConversationStarted += OnStarted;
        ConversationManager.OnConversationEnded += OnEnded;
        HideStone();
        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;
        StartConversation1();

    }

    public void StartConversation1()
    {
        current = StartDialog;
        ConversationManager.Instance.StartConversation(current);
        PlayerController.CanControll = false;
        StartCam.SetActive(true);
    }
    public void ShowStone()
    {
        Stone.SetActive(true);
    }
    public void HideStone()
    {
        Stone.SetActive(false);
    }
    public void OnStarted()
    {
        if(current == StartDialog)
        {
            Cursor.lockState = CursorLockMode.None;

            Cursor.visible = true;


        }
        else if(current == EndDialog)
        {
            Cursor.lockState = CursorLockMode.None;

            Cursor.visible = true;
        }
    }
    public void OnEnded()
    {
        if (current == StartDialog)
        {
            StartCam.SetActive(false);
            PlayerController.CanControll = true;
            Cursor.lockState = CursorLockMode.Locked;

            Cursor.visible = false;
        }
        else if (current == EndDialog)
        {
            sceneLoader.LoadScene("Menu");
        }
    }

    public void TriggerShow()
    {
        tamashiPlayer.SetTrigger("Show");
        ShowStone();
    }

    public void TriggerIdle()
    {
        tamashiPlayer.SetTrigger("ToIdle");
        HideStone();
    }

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
            FinishLine.SetActive(true);
        }
    }

    public void OnFinishLineReached()
    {
        current = EndDialog;
        ConversationManager.Instance.StartConversation(current);
        PlayerController.CanControll = false;
        StartCam.SetActive(true);
        PlayerController.getRb().isKinematic = true;
        PlayerController.getAnim().SetFloat("Speed", 0);
    }
}
