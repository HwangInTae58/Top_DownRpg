using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Conversation : MonoBehaviour, IInteractable
{
    GameManager manager;

    [SerializeField]
    private string title;

    [TextArea]
    public string[] conversation;

    int converIndex = 0;



    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public bool ReAction()
    {
        if (converIndex < conversation.Length)
        {
            manager.SetActiveDialog(true);
            manager.SetDialogContent(title, conversation[converIndex]);
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
