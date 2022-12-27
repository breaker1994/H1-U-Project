using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject Panel_Menu;
    public GameObject Panel_LevelSelect;
    public GameObject Panel_Settings;

    void Start()
    {
        Panel_Menu.SetActive(true);
        Panel_LevelSelect.SetActive(false);
        Panel_Settings.SetActive(false);
    }

    public void Enter_Settings()
    {
        Panel_Menu.SetActive(false);
        Panel_Settings.SetActive(true);
    }
    public void Enter_LevelSelect()
    {
        Panel_Menu.SetActive(false);
        Panel_LevelSelect.SetActive(true);
    }

    public void Exit_LevelSelect()
    {
        Panel_Menu.SetActive(true);
        Panel_LevelSelect.SetActive(false);
    }
    public void Exit_Settings()
    {
        Panel_Menu.SetActive(true);
        Panel_Settings.SetActive(false);
    }

    public void StartCampaign()
    {
        SceneManager.LoadScene("create hero");
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Panel_Menu.activeSelf)
            {
                Application.Quit();
            }
            else
            {
                if (Panel_Settings.activeSelf)
                {
                    Panel_Settings.SetActive(false);
                }
                else
                {
                    Panel_LevelSelect.SetActive(false);
                }
                Panel_Menu.SetActive(true);
            }
        }
    }
}
