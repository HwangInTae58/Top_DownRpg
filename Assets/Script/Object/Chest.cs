using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    GameManager manager;

    [SerializeField]
    public string Titlename;

    public string[] conversation;
    int converIndex = 0;
   
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    public bool ReAction()
    {
        if(converIndex < conversation.Length)
        {
            manager.SetActiveDialog(true);
            manager.SetDialogContent(Titlename, conversation[converIndex]);
            converIndex++;
            return true;
        }
        else
        {
            manager.SetActiveDialog(false);
            converIndex = 0;
            return false;
        }
        
    }
}
