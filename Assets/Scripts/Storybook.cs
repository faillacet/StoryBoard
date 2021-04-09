using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Storybook : MonoBehaviour
{
    public CanvasGroup PreviousButtonCanvasGroup;
    public CanvasGroup NextButtonCanvasGroup;
    public List<CanvasGroup> PageCanvasGroup;

    public List<Text> Texts;
    public List<Image> Images;

    protected int totalPages;
    protected int currentPage;

    public virtual void Start() {
        totalPages = PageCanvasGroup.Count;
        GoToPageOne();
    }

    public void OnPreviousButtonClick() {
        currentPage = currentPage - 1;
        if (currentPage < 1) {
            currentPage = 1;
        }  
        GoToPage(currentPage);
    }

    public void OnNextButtonClick() {
        currentPage = currentPage + 1;
        if (currentPage > totalPages)
            currentPage = totalPages;
        GoToPage(currentPage);
    }

    public void UpdatePages() {
        foreach (CanvasGroup canvasGroup in PageCanvasGroup) {
            Hide(canvasGroup);
        }
        Show(PageCanvasGroup[currentPage-1]);
    }

    public void UpdateButtons() {
        Show(PreviousButtonCanvasGroup);
        Show(NextButtonCanvasGroup);
        if (currentPage == 1) {
            Hide(PreviousButtonCanvasGroup);
        }
        if (currentPage == totalPages) {
            Hide(NextButtonCanvasGroup);
        }
    }

    public void SetImage(int pageNumber, string imageName) {
        Images[pageNumber-1].sprite = GetSprite(imageName);
    }

    public void SetText(int pageNumber, string inputText) {
        Texts[pageNumber-1].text = inputText;
    }

    public void GoToPageOne() {
        GoToPage(1);
    }

    private void GoToPage(int pageNumber) {
        currentPage = pageNumber;
        UpdatePages();
        UpdateButtons();
    }

    private Sprite GetSprite(string imageName) {
        return Resources.Load<Sprite>("Art/" + imageName);
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
