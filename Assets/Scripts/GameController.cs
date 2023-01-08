using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject GameUX;
    public GameObject BackgroundBlock;

    public static bool imageIsShowed = false;

    public void showImage()
    {
        if (imageIsShowed)
        {
            return;
        }

        imageIsShowed = true;
        Animator BackgroundBlockController = BackgroundBlock.GetComponent<Animator>();

        GameUX.SetActive(false);
        BackgroundBlockController.Play("Background Fade Out");
    }

    public void hideImage()
    {
        if (!imageIsShowed)
        {
            return;
        }

        Animator BackgroundBlockController = BackgroundBlock.GetComponent<Animator>();

        BackgroundBlockController.Play("Background Fade In");

    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Main");
    }

    /*void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        Debug.Log("Scene disable");
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Level Loaded " + scene.name + " " + mode);
    }*/
}
