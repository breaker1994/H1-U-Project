using UnityEngine;
using System.Collections.Generic;
//using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

public class CreateTargetList : MonoBehaviour
{
    public GameObject sampleButton;
    public Transform contentPanel;

    void Start()
    {

    }

    public void AddItem()
    {
        /*string[] Quests = QuestLog.GetAllQuests();
        Debug.Log("AddItem "+ Quests.Length);
        for (int i = 0; i < Quests.Length; i++)
        {
            AddItem(Quests[i]);
        }*/
    }

    public void AddItem(string questName)
    {
        /*GameObject newButton = Instantiate(sampleButton) as GameObject;
        TargetListButton button = newButton.GetComponent<TargetListButton>();

        button.targetName.text = newButton.name = questName;
        button.targetProcess.text = QuestLog.GetQuestDescription(questName);
        if (button.targetProcess.text.Length > 30)
        {
            button.targetProcess.text = button.targetProcess.text.Remove(27) + "...";
        }

        button.button.onClick.AddListener(delegate () { ClickFunction(questName); });
        newButton.transform.SetParent(contentPanel, false);*/
    }
    public void ClearTargetList()
    {
        foreach (Transform child in transform.GetChild(0).GetChild(0))
        {
            if (child.gameObject.activeSelf)
            {
                Destroy(child.gameObject);
            }
        }
    }

    public void ClickFunction(string name)
    {
        foreach (Transform item in transform.GetChild(0).GetChild(0))
        {
            Text buttonText = item.GetChild(1).gameObject.GetComponent<Text>();
            TargetListButton button = item.GetComponent<TargetListButton>();

            if (item.gameObject.name == name && !button.isDetailed)
            {
                //string description = QuestLog.GetQuestDescription(name);
                string description = "TEMP";
                if (description.Length > 30)
                {
                    buttonText.text = description;
                    button.isDetailed = true;
                }
            }
            else
            {
                if (button.isDetailed && buttonText.text.Length > 30)
                {
                    buttonText.text = buttonText.text.Remove(27) + "...";
                    button.isDetailed = false;
                }
            }
        }
    }

    void Update()
    {

    }
}