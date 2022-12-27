using UnityEngine;

public class CreateMainList : MonoBehaviour
{
    public GameObject listItem;
    public Transform contentPanel;

    void Start()
    {
        AddItem("I need you, more than anything.\r\nYour phosphorescent organs are so beautiful... so beautiful.");
        AddItem("I need you, more than anything.\r\nYour phosphorescent organs are so beautiful... so beautiful.");
        AddItem("I need you, more than anything.\r\nYour phosphorescent organs are so beautiful... so beautiful.");
    }

    public void AddItem(string text)
    {
        Debug.Log("AddItem: " + text);
        GameObject newItem = Instantiate(listItem) as GameObject;
        MainListItem mainListItem = newItem.GetComponent<MainListItem>();

        mainListItem.text.text = text;
        mainListItem.transform.SetParent(contentPanel, false);
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

    void Update()
    {

    }
}