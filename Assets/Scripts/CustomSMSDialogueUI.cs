using PixelCrushers.DialogueSystem;
using System.Collections.Generic;

public class CustomSMSDialogueUI : SMSDialogueUI
{
    protected override StandardUISubtitlePanel GetTemplate(Subtitle subtitle)
    {
        var panelNumber = DialogueActor.GetSubtitlePanelNumber(subtitle.speakerInfo.transform);
        return (panelNumber == SubtitlePanelNumber.Default) 
            ? base.GetTemplate(subtitle)
            : conversationUIElements.subtitlePanels[PanelNumberUtility.GetSubtitlePanelIndex(panelNumber)];

    }
}
