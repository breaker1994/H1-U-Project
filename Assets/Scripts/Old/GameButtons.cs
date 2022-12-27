using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
//using PixelCrushers.DialogueSystem;

public class GameButtons : MonoBehaviour {

    public GameObject Panel_List;
    public GameObject Panel_Hero;
    public GameObject Panel_Targets;
    public GameObject Panel_Settings;

    public Button Button_Tab_List;
    public Button Button_Tab_Hero;
    public Button Button_Tab_Targets;
    public Button Button_Tab_Settings;

    public int currentYear;
    public int currentMonth;
    public int currentMoney;
    public int currentFrame;
    public int currentPlaceID;

    public TextAsset placesXML;

    void Start () {
        currentMonth = PlayerPrefs.GetInt("Month");
        currentYear = PlayerPrefs.GetInt("Year");
        transform.Find("Indicators").GetChild(1).gameObject.GetComponent<Text>().text = 
            GetMonthName(currentMonth)+" "+ 
            Mathf.Abs(currentYear) + 
            (currentYear < 0 ? " г. до н.э." : "г.");

        currentMoney = PlayerPrefs.GetInt("Money");
        transform.Find("Indicators").GetChild(2).gameObject.GetComponent<Text>().text = "Деньги: " + currentMoney;

        currentFrame = 1;
        currentPlaceID = 1;

        ChangeTheFrame(1);
        GenerateEventList();
    }

    public void GenerateEventList()
    {
        XmlDocument xmlDoc = new XmlDocument(); 
        xmlDoc.LoadXml(placesXML.text);
        XmlNodeList levelsList = xmlDoc.GetElementsByTagName("place");
        for(int i=0; i< levelsList.Count; ++i)
        {
            if(int.Parse(levelsList[i].Attributes["id"].Value) == currentPlaceID)
            {
                Debug.Log(levelsList[i].ChildNodes.Count+" "+ levelsList[i].Name);
                foreach (XmlNode item in levelsList[i].ChildNodes)
                {
                    Debug.Log(item.InnerText + " " + item.Attributes["dialogueid"].Value);
                    Panel_List.transform.GetChild(0).gameObject.GetComponent<CreateEventList>().AddItem(
                        item.InnerText,
                        int.Parse(item.Attributes["dialogueid"].Value));
                }
                break;
            }
        }
    }

    public void ChangeTheFrame(int frameNum)
    {
        if (frameNum != currentFrame)
        {
            switch (currentFrame)
            {
                case 1:
                    Button_Tab_List.interactable = true;
                    Panel_List.SetActive(false);
                    break;
                case 2:
                    Button_Tab_Hero.interactable = true;
                    Panel_Hero.SetActive(false);
                    break;
                case 3:
                    //Panel_Targets.transform.GetChild(0).gameObject.GetComponent<CreateTargetList>().ClearTargetList();
                    //Button_Tab_Targets.interactable = true;
                    //Panel_Targets.SetActive(false);
                    break;
                case 4:
                    Button_Tab_Settings.interactable = true;
                    Panel_Settings.SetActive(false);
                    break;
            }
            currentFrame = frameNum;
        }
        switch (currentFrame)
        {
            case 1:
                Debug.Log("ENTER LIST");
                Button_Tab_List.interactable = false;
                Panel_List.SetActive(true);
                break;
            case 2:
                Debug.Log("ENTER HERO");
                Button_Tab_Hero.interactable = false;
                Panel_Hero.SetActive(true);
                MakeHeroPage();
                break;
            case 3:
                Debug.Log("ENTER TARGETS");
                Button_Tab_Targets.interactable = false;
                Panel_Targets.SetActive(true);
                //Panel_Targets.transform.GetChild(0).gameObject.GetComponent<CreateTargetList>().AddItem();
                break;
            case 4:
                Debug.Log("ENTER SETTINGS");
                Button_Tab_Settings.interactable = false;
                Panel_Settings.SetActive(true);
                break;
        }
    }

    public void MakeATurn()
    {
        if (currentMonth == 12)
        {
            currentMonth = 1;
            ++currentYear;
        }
        else
        {
            ++currentMonth;
        }
        PlayerPrefs.SetInt("Month", currentMonth);
        PlayerPrefs.SetInt("Year", currentYear);
        PlayerPrefs.Save();

        transform.Find("Indicators").GetChild(1).gameObject.GetComponent<Text>().text = 
            GetMonthName(currentMonth) + " " +
            Mathf.Abs(currentYear) +
            (currentYear < 0 ? " г. до н.э." : "г.");
    }

    public string GetMonthName(int monthNumber)
    {
        string[] months = new string[] {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
        return months[0];
        //return months[monthNumber - 1];
    }

    public void MakeHeroPage()
    {
        Panel_Hero.transform.GetChild(0).gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("Name") + " Орфас";
        Panel_Hero.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Возраст: " + PlayerPrefs.GetInt("Age");

        Panel_Hero.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Здоровье: "+PlayerPrefs.GetInt("Health");
        Panel_Hero.transform.GetChild(3).gameObject.GetComponent<Text>().text = "Интеллект: " + PlayerPrefs.GetInt("Intellect");
        Panel_Hero.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Харизма: " + PlayerPrefs.GetInt("Charisma");
        Panel_Hero.transform.GetChild(5).gameObject.GetComponent<Text>().text = "Воля: " + PlayerPrefs.GetInt("Will");
    }

    public void Exit_Game()
    {
        SceneManager.LoadScene("main");
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit_Game();
        }
    }
}
