using UnityEngine;
using UnityEngine.Events;

public class AnimatorEventHandler : MonoBehaviour
{
    public GameObject GameUX;
    public UnityEvent onFade = new UnityEvent();

    public void ImageFadeIn()
    {
        Debug.Log("ImageFadeIn");

        GameUX.SetActive(true);
        GameController.imageIsShowed = false;
    }

    public void BackgroundFadeIn()
    {
        Debug.Log("BackgroundFadeIn");

        onFade.Invoke();
    }
}