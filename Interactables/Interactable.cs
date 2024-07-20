using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactionText = "Press E to interact";

    public virtual void Interact() {}

    public virtual void ShowPrompt(bool show)
    {
        ChangePromptText();
        PlayerUIManager.Instance.interactionPrompt.SetActive(show);
    }

    public void ChangePromptText()
    {
        PlayerUIManager.Instance.interactionText.text = interactionText;
    }
}
