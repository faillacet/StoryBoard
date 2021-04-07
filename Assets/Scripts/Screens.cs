using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screens : MonoBehaviour
{
    public CanvasGroup MainScreen;
    public CanvasGroup SelectScreen;
    public CanvasGroup StoryScreen;

    void Start() {
        ShowMainScreen();
    }

    public void ShowMainScreen() {
        Show(MainScreen);
        Hide(SelectScreen);
        Hide(StoryScreen); 
    }

    public void ShowSelectScreen() {
        Hide(MainScreen);
        Show(SelectScreen);
        Hide(StoryScreen); 
    }

    public void ShowStoryScreen() {
        Hide(MainScreen);
        Hide(SelectScreen);
        Show(StoryScreen); 
    }

    public void QuitApplication() {
        print("Quit");
        Application.Quit();
    }

    protected void Show(CanvasGroup canvasGroup) {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    protected void Hide(CanvasGroup canvasGroup) {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
