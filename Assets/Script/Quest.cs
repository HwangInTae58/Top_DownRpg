using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum QuestType
{
    GATHER,
    KILL,
    ESCORT,
    DELIVERY,
}

[System.Serializable]
public class Quest : MonoBehaviour
{
    public UnityAction<Quest> OnStart;
    public UnityAction<Quest> OnComplete;

    QuestManager manager;

    public QuestType type;

    public string title;

    [TextArea]
    public string description;

    public string requirementName;

    public int curAmount;
    public int requireAmount;

    public ItemData itemReward;
    public int expReward;
    public int goldReward;

    public Conversation accept, progress, complete;

    public bool isActive = false;
    public bool isStarted = false;
    public bool isFinished = false;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("QuestManager").GetComponent<QuestManager>();
        OnStart += QuestManager.instance.QuestStart;
        OnComplete += QuestManager.instance.QuestComplete;
    }

    public void Accept()
    {
        isStarted = true;
        Debug.Log(title + " was Accepted!");
    }

    public void Progress()
    {
        curAmount++;
        Debug.Log(title + " was Progress! - " + curAmount + "/" + requireAmount);
    }

    public void Complete()
    {
        isActive = false;
        OnComplete.Invoke(this);
        Debug.Log(title + " was Complete!");
    }

    public bool ReAction()
    {
        if (!isStarted)
        {
            bool reaction = accept.ReAction();
            if (reaction)
            {
                return true;
            }
            else
            {
                OnStart?.Invoke(this);
                Accept();
                return false;
            }
        }
        else if (!isFinished)
        {
            if (curAmount < requireAmount)
                return progress.ReAction();
            else
            {
                isFinished = true;
                return ReAction();
            }
        }
        else
        {
            bool reaction = complete.ReAction();
            if (reaction)
            {
                return true;
            }
            else
            {
                Complete();
                return false;
            }
        }
    }
}
