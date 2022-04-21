using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public Conversation conversation;

    private Quest[] quests;

    private void Start()
    {
        quests = GetComponentsInChildren<Quest>();
    }

    public bool ReAction()
    {
        // 퀘스트가 있는지 확인
        Quest next = null;
        foreach (Quest quest in quests)
        {
            if (quest.isActive)
            {
                next = quest;
                break;
            }
        }

        if (null != next) // 2. 퀘스트 상호작용 시작
        {
            return next.ReAction();
        }
        else // 3. 퀘스트가 없을 때
        {
            return conversation.ReAction();
        }
    }
}
