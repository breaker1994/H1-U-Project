using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyUI.Toast;

public class MenuButtons : MonoBehaviour
{
    public GameObject Panel_Menu;
    public GameObject Panel_LevelSelect;
    public GameObject Panel_Settings;

    private int backClick = 0;

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
        SceneManager.LoadScene("Game");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Panel_Menu.activeSelf)
            {
                ++backClick;
                if(backClick == 1)
                {
                    Debug.Log("Double Click");
                    Toast.Show("Press again to exit", 1f);
                }

                StartCoroutine(ClickTime());

                if (backClick > 1)
                {
                    #if UNITY_EDITOR
                    EditorApplication.isPlaying = false;
                    #else
                    Application.Quit ();
                    #endif
                }
            }
            else
            {
                StopAllCoroutines();
                backClick = 0;

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

    IEnumerator ClickTime()
    {
        yield return new WaitForSeconds(0.5f);
        backClick = 0;
    }
}
