using UnityEngine;
using UnityEngine.EventSystems;
using PixelCrushers.DialogueSystem.Extras;
using UnityEngine.Events;

public class ScrollContentEventsHandler : MonoBehaviour, IPointerClickHandler {
    public TextlineDialogueUI textlineDialogueUI = null;
    public UnityEvent onClick = new UnityEvent();

    public void OnPointerClick(PointerEventData data)
    {
        Debug.Log("Scroll OnPointerClick " + this.name);
        onClick.Invoke();
    }
}
