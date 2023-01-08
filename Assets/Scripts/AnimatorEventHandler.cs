using UnityEngine;

public class AnimatorEventHandler : MonoBehaviour
{
    public GameObject GameUX;

    public void ImageFadeIn()
    {
        Debug.Log("ImageFadeIn");

        GameUX.SetActive(true);
        GameController.imageIsShowed = false;
    }
}