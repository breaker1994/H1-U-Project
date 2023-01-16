using PixelCrushers.DialogueSystem.Extras;
public class CustomTextlineDialogueUI : TextlineDialogueUI
{
    public void ClearCurrentContent()
    {
        records.Clear();
        DestroyInstantiatedMessages();
    }
}