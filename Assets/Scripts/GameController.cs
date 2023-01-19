using PixelCrushers.DialogueSystem;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject GameUX;

    public Animator allFadeAnimator;
    public Animator backgroundFadeAnimator;

    public static bool imageIsShowed = false;
    public static bool conversationIsChanging = false;

    public void showImage()
    {
        if (imageIsShowed)
        {
            return;
        }

        imageIsShowed = true;

        GameUX.SetActive(false);
        backgroundFadeAnimator.Play("Background Fade Out");
    }

    public void hideImage()
    {
        if (!imageIsShowed)
        {
            return;
        }

        backgroundFadeAnimator.Play("Background Fade In");
    }

    public void changeConversation()
    {
        Debug.Log("changeConversation from "+ DialogueManager.lastConversationEnded);

        conversationIsChanging = true;
        allFadeIn();
    }

    public void allFadeIn()
    {
        Debug.Log("allFadeIn");

        allFadeAnimator.Play("All Fade In");
    }

    public void AllIsFaded()
    {
        Debug.Log("AllIsFaded");

        if (conversationIsChanging)
        {
            conversationIsChanging = false;

            Conversation oldConversation = DialogueManager.masterDatabase.GetConversation(DialogueManager.lastConversationEnded);
            string nextScene = DialogueLua.GetConversationField(oldConversation.id, "nextScene").asString;

            Conversation newConversation = DialogueManager.masterDatabase.GetConversation(nextScene);

            DialogueManager.StartConversation(nextScene);

            Boolean isImage = DialogueLua.GetConversationField(newConversation.id, "isImage").asBool;

            imageIsShowed = isImage;

            if (isImage)
            {
                backgroundFadeAnimator.Play("Idle_NOFADE");
            }
            else
            {
                backgroundFadeAnimator.Play("Default");
            }

            Debug.Log("nextScene: " + nextScene + " isImage: " + isImage);
        }

        allFadeOut();
    }

    public void allFadeOut()
    {
        Debug.Log("allFadeOut");

        allFadeAnimator.Play("All Fade Out");
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
