using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryData
{
    public const int NumberOfPages = 8;
    
    private string authors;
    private string selectionScreenImageName;
    private List<string> imageNames;
    private List<string> texts;

    private int pageNumber = 0;
    private const string defaultImageName = "pic1";
    private const string defaultText = "default text";

    public StoryData(string authors) {
        this.authors = authors;
        imageNames = new List<string>();
        for (int i = 0; i < 8; i++) {
            imageNames.Add(defaultImageName);
        }
        texts = new List<string>();
        for (int i = 0; i < 8; i++) {
            texts.Add(defaultText);
        }
    }

    public void SetSelectionScreenImage(string imageName) {
        selectionScreenImageName = imageName;
    }

    public void AddPage(string imageName, string text) {
        imageNames[pageNumber] = imageName;
        texts[pageNumber] = text;
        pageNumber++;
        if (pageNumber == NumberOfPages) {
            pageNumber = NumberOfPages - 1;
        }
    }

    public string GetAuthors() {
        return authors;
    }

    public string GetSelectionScreenImage() {
        return selectionScreenImageName;
    }

    public string GetImageName(int pageNumber) {
        if (pageNumber < 1 || pageNumber > NumberOfPages)
            return defaultImageName;
        return imageNames[pageNumber-1];
    }

     public string GetText(int pageNumber) {
        if (pageNumber < 1 || pageNumber > NumberOfPages)
            return defaultText;
        return texts[pageNumber-1];
    }
}
