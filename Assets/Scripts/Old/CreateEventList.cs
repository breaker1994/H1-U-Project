using UnityEngine;
//using PixelCrushers.DialogueSystem;

public class CreateEventList : MonoBehaviour {
    public GameObject sampleButton;
    public Transform contentPanel;

	void Start () {

	}

    public void AddItem(string text, int id)
    {
        Debug.Log("AddItem: "+ text + " "+ id);
        GameObject newButton = Instantiate(sampleButton) as GameObject;
        EventListButton button = newButton.GetComponent<EventListButton>();

        button.eventName.text = text;
        button.eventType.text = "!";

        button.button.onClick.AddListener(delegate () { ClickFunction(id); });
        newButton.transform.SetParent(contentPanel, false);
    }

    public void ClickFunction(int id)
    {
        //Debug.Log(DialogueManager.MasterDatabase.GetConversation(id).Title);
        //EventWindow.SetActive(true);
        //DialogueManager.StartConversation(DialogueManager.MasterDatabase.GetConversation(id).Title);
    }

    void Update () {
		
	}
}
