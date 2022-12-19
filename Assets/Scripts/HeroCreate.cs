using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroCreate : MonoBehaviour {
    public InputField TextField;

    public Text HeroDescription;
    public Text ParametersCount;

    public GameObject NameChooseBlock;
    public GameObject ParametersChooseBlock;

    public int remainingPoints = 15;

    public string HeroName;

    public int HeroWill;
    public int HeroCharisma;
    public int HeroIntellect;
    public int HeroHealth;

    void Start () {
        GetRandomName();
    }

    public void GetRandomName()
    {
        Debug.Log("GETTING NEW NAME");
        string[] names = new string[] {"Юлий", "Гай", "Публий", "Септимий", "Квинт", "Марк", "" };
        TextField.text = names[Random.Range(0, 6)];
    }

    public void ResetParameters()
    {
        foreach (Transform child in ParametersChooseBlock.transform)
        {
            if (child.childCount > 1)
            {
                remainingPoints = 15;
                ParametersCount.text = "Очков улучшений: 15";
                child.GetChild(0).GetComponent<Text>().text = "1";
                child.GetChild(2).GetComponent<Button>().interactable = true;
                child.GetChild(3).GetComponent<Button>().interactable = false;
            }
        }
    }

    public void MinusParameter(GameObject target)
    {
        ParametersCount.text = "Очков улучшений: " + (++remainingPoints);
        Text NumberText = target.transform.GetChild(0).gameObject.GetComponent<Text>();
        int currentNumberText = int.Parse(NumberText.text);
        NumberText.text = (--currentNumberText).ToString();
        if (remainingPoints==15)
        {
            Debug.Log("DISABLE MINUS BUTTONS");
            foreach (Transform child in target.transform.parent)
            {
                if (child.childCount > 1)
                {
                    child.GetChild(3).GetComponent<Button>().interactable = false;
                }
            }
        }
        else
        {
            if(currentNumberText==1)
            {
                target.transform.GetChild(3).GetComponent<Button>().interactable = false;
            }
            if(remainingPoints==1)
            {
                Debug.Log("ENABLE PLUS BUTTONS");
                foreach (Transform child in target.transform.parent)
                {
                    if (child.childCount > 1)
                    {
                        child.GetChild(2).GetComponent<Button>().interactable = true;
                    }
                }
            }
        }
    }

    public void PlusParameter(GameObject target)
    {
        ParametersCount.text = "Очков улучшений: " + (--remainingPoints);
        Text NumberText = target.transform.GetChild(0).gameObject.GetComponent<Text>();
        int currentNumberText = int.Parse(NumberText.text);
        NumberText.text = (++currentNumberText).ToString(); 
        if (remainingPoints == 0)
        {
            Debug.Log("DISABLE PLUS BUTTONS");
            foreach (Transform child in target.transform.parent)
            {
                if(child.childCount>1)
                {
                    child.GetChild(2).GetComponent<Button>().interactable = false;
                }
            }
        }
        if(currentNumberText==2)
        {
            target.transform.GetChild(3).GetComponent<Button>().interactable = true;
        }
    }

    public void ParametersChosen()
    {
        HeroHealth = int.Parse(ParametersChooseBlock.transform.Find("HealthBlock").GetChild(0).GetComponent<Text>().text);
        HeroIntellect = int.Parse(ParametersChooseBlock.transform.Find("IntellectBlock").GetChild(0).GetComponent<Text>().text);
        HeroCharisma = int.Parse(ParametersChooseBlock.transform.Find("CharismaBlock").GetChild(0).GetComponent<Text>().text);
        HeroWill = int.Parse(ParametersChooseBlock.transform.Find("WillBlock").GetChild(0).GetComponent<Text>().text);

        PlayerPrefs.SetInt("Health", HeroHealth);
        PlayerPrefs.SetInt("Intellect", HeroIntellect);
        PlayerPrefs.SetInt("Charisma", HeroCharisma);
        PlayerPrefs.SetInt("Will", HeroWill);
        PlayerPrefs.Save();

        HeroDescription.text = "В семье видного римского военачальника Гая Корнелия Орфаса родился сын. Мальчику дали имя " + HeroName + ".\n\n";

        if(Mathf.Max(HeroHealth, HeroIntellect, HeroCharisma, HeroWill)<6)
        {
            HeroDescription.text += "И хотя природа не была слишком уж благосклонна к отпрыску Орфасов, радости его родителей не было предела.";
        }
        else
        {
            int tempInt = 0;
            HeroDescription.text += "Природа щедро одарила отпрыска Орфасов";
            if (HeroHealth > 5)
            {
                HeroDescription.text += " отменным здоровьем,";
                ++tempInt;
            }
            if (HeroIntellect > 5)
            {
                HeroDescription.text += " цепким, пытливым умом,";
                ++tempInt;
            }
            if (HeroCharisma > 5)
            {
                HeroDescription.text += " мощной харизмой,";
                ++tempInt;
            }
            if (HeroWill > 5)
            {
                HeroDescription.text += " несгибаемым характером,";
                ++tempInt;
            }
            string tempText = HeroDescription.text;
            tempText = tempText.Substring(0, tempText.Length - 1)+".";
            if (tempInt > 1)
            {
                tempInt = tempText.LastIndexOf(",");
                tempText = tempText.Insert(tempInt + 1, " и").Remove(tempInt, 1);
            }
            HeroDescription.text = tempText;
        }

        ParametersChooseBlock.SetActive(false);
        NameChooseBlock.transform.parent.Find("Button_Start").gameObject.SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("Year", -62);
        PlayerPrefs.SetInt("Month", 1);
        PlayerPrefs.SetInt("Money", 50);
        PlayerPrefs.SetInt("Age", 18);
        PlayerPrefs.Save();

        SceneManager.LoadScene("game");
    }

    public void NameChosen()
    {
        HeroName = TextField.text;
        PlayerPrefs.SetString("Name", HeroName);
        PlayerPrefs.Save();

        NameChooseBlock.SetActive(false);
        HeroDescription.text = 
            "В семье видного римского военачальника Гая Корнелия Орфаса родился сын. Мальчику дали имя " +
            HeroName +
            ".\n\nПрирода щедро наградила отпрыска Орфасов...";
        ParametersChooseBlock.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("main");
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("main");
        }
    }
}
