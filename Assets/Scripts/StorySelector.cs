using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class StorySelector : Storybook
{
   public List<Image> StorySelectionImage;
   public List<Text> StorySelectionText;
   public Storybook Story;
   public TextAsset TextFile;

   private List<StoryData> storyDatas;

    public override void Start() {
        base.Start();
        LoadStoryData();
        PopulateSelections();
    }

    private void LoadStoryData() {
        string rawText = TextFile.text;
        storyDatas = new List<StoryData>();
        using (StringReader stringReader = new StringReader(rawText)) {
            string line;
            while((line = stringReader.ReadLine()) != null) {
                StoreOneStory(line, stringReader);
            }
        }
    }

    private void StoreOneStory(string line, StringReader stringReader) {
        StoryData storyData;
        storyData = new StoryData(line);
        storyData.SetSelectionScreenImage(stringReader.ReadLine());
        for (int pageNumber = 0; pageNumber < StoryData.NumberOfPages; pageNumber++) {
            string textLine = stringReader.ReadLine();
            string imageLine = stringReader.ReadLine();
            storyData.AddPage(imageLine, textLine);
        }

        storyDatas.Add(storyData);
    }

    private void PopulateSelections() {
        for (int i = 0; i < storyDatas.Count; i++) {
            string imageName = storyDatas[i].GetSelectionScreenImage();
            StorySelectionImage[i].sprite = GetSprite(imageName);
            StorySelectionText[i].text = storyDatas[i].GetAuthors();
        }
    }

    public void OnStorySelection(int storyNumber) {
        StoryData selectedStory = storyDatas[storyNumber];

        for (int pageNumber = 1; pageNumber <= StoryData.NumberOfPages; pageNumber++) {
            Story.SetImage(pageNumber, selectedStory.GetImageName(pageNumber));
            Story.SetText(pageNumber, selectedStory.GetText(pageNumber));
        }

        Story.GoToPageOne();
    }

    public void OnRandomStory() {
        int randomStoryNumber = Random.Range(0, storyDatas.Count - 1);
        OnStorySelection(randomStoryNumber);
    }

    private Sprite GetSprite(string imageName) {
        return Resources.Load<Sprite>("Art/" + imageName);
    }
}
