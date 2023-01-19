using UnityEngine;
using UnityEngine.Events;

public class AnimatorEventHandler : MonoBehaviour
{
    public UnityEvent onFade = new UnityEvent();
    public UnityEvent onImageFade = new UnityEvent();

    public void ImageFadeIn()
    {
        Debug.Log("ImageFadeIn");

        onImageFade.Invoke();
    }

    public void BackgroundFadeIn()
    {
        Debug.Log("BackgroundFadeIn");

        onFade.Invoke();
    }
}