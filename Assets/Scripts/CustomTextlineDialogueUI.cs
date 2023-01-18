using PixelCrushers.DialogueSystem.Extras;
using System;
using UnityEngine;

public class CustomTextlineDialogueUI : TextlineDialogueUI
{
    public void ClearCurrentContent()
    {
        try
        {
            if (records.Count > 0)
            {
                records.Clear();
            }
            DestroyInstantiatedMessages();
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
        }
    }

    public override void OnContinue()
    {
        base.OnContinue();
    }
}