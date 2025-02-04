﻿using PixelCrushers.DialogueSystem;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Animator allFadeAnimator;
    public Animator backgroundFadeAnimator;

    public GameObject backgroundImage;

    public static bool imageIsShowed = false;
    public static bool conversationIsChanging = false;

    public void showImage()
    {
        if (imageIsShowed)
        {
            return;
        }

        imageIsShowed = true;

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

    public void ImageIsFaded()
    {
        if (conversationIsChanging)
        {
            conversationIsChanging = false;

            Conversation oldConversation = DialogueManager.masterDatabase.GetConversation(DialogueManager.lastConversationEnded);
            string nextScene = DialogueLua.GetConversationField(oldConversation.id, "nextScene").asString;

            Conversation newConversation = DialogueManager.masterDatabase.GetConversation(nextScene);

            DialogueManager.StartConversation(nextScene);
        }

        GameController.imageIsShowed = false;
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

    public void OnConversationStart()
    {
        Debug.Log("OnConversationStart " + DialogueManager.lastConversationStarted);

        Conversation newConversation = DialogueManager.masterDatabase.GetConversation(DialogueManager.lastConversationStarted);

        Boolean isImage = DialogueLua.GetConversationField(newConversation.id, "isImage").asBool;

        imageIsShowed = isImage;

        if (isImage)
        {
            backgroundFadeAnimator.Play("Idle_NOFADE");
            string imageString = DialogueLua.GetConversationField(newConversation.id, "imageFile").asString;
            Sprite backgroundSprite = Resources.Load<Sprite>("Images/"+imageString);

            float realWidth = backgroundSprite.rect.width;
            float realHeight = backgroundSprite.rect.height;
            float aspectRatio = (float)Math.Round(realWidth / realHeight, 1);

            Debug.Log("imageString " + imageString);
            Debug.Log("backgroundSprite " + backgroundSprite);
            Debug.Log("realWidth: " + realWidth+ " realHeight: " + realHeight+ " aspectRatio: "+ aspectRatio);

            backgroundImage.GetComponent<Image>().sprite = backgroundSprite;
            backgroundImage.GetComponent<AspectRatioFitter>().aspectRatio = aspectRatio;
        }
        else
        {
            backgroundFadeAnimator.Play("Default");
        }
    }
    public void OnConversationEnd()
    {
        Conversation oldConversation = DialogueManager.masterDatabase.GetConversation(DialogueManager.lastConversationEnded);
        Boolean needAllFade = DialogueLua.GetConversationField(oldConversation.id, "needAllFade").asBool;

        Debug.Log("OnConversationEnd: " + oldConversation.ToString() + " needAllFade:" + needAllFade);

        conversationIsChanging = true;

        if(needAllFade)
        {
            allFadeIn();
        }
        else
        {
            hideImage();
        }
    }
}   
