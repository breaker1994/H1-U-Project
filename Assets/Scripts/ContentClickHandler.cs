using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ContentClickHandler : MonoBehaviour, IPointerClickHandler {
    public UnityEvent onClick = new UnityEvent();

    public void OnPointerClick(PointerEventData data)
    {
        if (GameController.conversationIsChanging)
        {
            return;
        }

        Debug.Log("Scroll OnPointerClick " + this.name);

        onClick.Invoke();
    }
}