using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject GameUX;
    public GameObject BackgroundBlock;
    public GameObject MainCanvasBlock;
    public GameObject ScreenAlpha;
    public GameObject imageDialogueUI;
    public CustomTextlineDialogueUI defaultDialogueUI;

    public static bool imageIsShowed = false;
    public static bool conversationIsChanging = false;
    private static string nextChapter = null;

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

    public void changeConversation()
    {
        Debug.Log("changeConversation "+ DialogueManager.lastConversationEnded);

        var conversation = DialogueManager.masterDatabase.GetConversation(DialogueManager.lastConversationEnded);
        string tags = DialogueLua.GetConversationField(conversation.id, "nextScene").asString;

        nextChapter = tags;
        allFadeIn();
    }

    public void allFadeIn()
    {
        Debug.Log("allFadeIn");

        Animator MainCanvasBlockController = MainCanvasBlock.GetComponent<Animator>();

        //GameUX.SetActive(false);
        MainCanvasBlockController.Play("All Fade In");
    }

    public void AllIsFaded()
    {
        if(nextChapter != null)
        {
            DialogueManager.StartConversation(nextChapter);
            nextChapter = null;
        }
        showImage();
        allFadeOut();
    }

    public void allFadeOut()
    {
        Debug.Log("allFadeOut");

        Animator MainCanvasBlockController = MainCanvasBlock.GetComponent<Animator>();

        MainCanvasBlockController.Play("All Fade Out");
    }

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
        Debug.Log("Level Loaded " + scene.name + " " + mode);
        allFadeOut();
    }
}
