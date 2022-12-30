using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Main");
    }
    void OnEnable()
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
        Debug.Log("Level Loaded "+ scene.name+" "+ mode);
    }
}
