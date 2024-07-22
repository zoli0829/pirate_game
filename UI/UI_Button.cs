using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        //ATTACH AN ON CLICK EVENT LISTENER TO PLAY THE SOUND FX
        button.onClick.AddListener(PlayPressedSoundFX);
    }

    private void PlayPressedSoundFX()
    {
        AudioManager.Instance.PlayButtonClickSoundFX();
    }
}
