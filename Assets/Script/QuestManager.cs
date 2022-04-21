using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public GameObject ui;

    private Quest curQuest;

    public void QuestStart(Quest quest)
    {
        Debug.Log("퀘스트 시작");
        Debug.Log("퀘스트 이름 : " + quest.title);
        Debug.Log("퀘스트 설명 : " + quest.description);
        curQuest = quest;
    }

    public void QuestComplete(Quest quest)
    {
        Debug.Log("퀘스트 완료");
        Debug.Log("퀘스트 보상 골드 : " + quest.goldReward);
        Debug.Log("퀘스트 보상 경험치 : " + quest.expReward);
        curQuest = null;
    }

    public void OnItemGather(string itemName)
    {
        if (null == curQuest)
            return;
        if (curQuest.type != QuestType.GATHER)
            return;
        if (curQuest.requirementName != itemName)
            return;

        curQuest.Progress();
    }

    public void OnMonsterDie(string monsterName)
    {
        if (null == curQuest)
            return;
        if (curQuest.type != QuestType.KILL)
            return;
        if (curQuest.requirementName != monsterName)
            return;

        curQuest.Progress();
    }
}