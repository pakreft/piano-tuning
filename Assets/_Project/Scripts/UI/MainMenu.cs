using UnityEngine;
using System;

public class MainMenu : MonoBehaviour
{
    public static event Action OnPlayButton, OnOptionsButton, OnExitButton;

    public void PlayButtonOnClick() => OnPlayButton.Invoke();

    public void OptionsButtonOnClick() => OnOptionsButton.Invoke();

    public void ExitButtonOnClick() => OnExitButton.Invoke();
}
