using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScreenshotDisplayManager : Singleton<ScreenshotDisplayManager> {

    public GameObject imagePosition;
    public Image gameImagePrefab;

    public float GRID_Y_OFFSET = 60;

    public float smallScale;

    public Material currentScreenshot;
    public Material otherScreenshot;


    public bool moving { get; set; }

    List<Game> playlist;

    Image[] screens;

    List<GameImage> imageList;
    
    int currentScreenIndex = 0;
    

    void Start() {

        imageList = new List<GameImage>();

        playlist = GameRepository.Instance.games;        

        createScreenshots();
    }

    void createScreenshots() {

        foreach (Game game in playlist) {

            var image = Instantiate(gameImagePrefab) as Image;
            image.sprite = game.screenshot;
            image.transform.parent = transform;

            image.GetComponent<GameImage>().screenshotDisMan = this;

            imageList.Add(image.GetComponent<GameImage>());
        }

        sortImageList(2);
    }

    public void sortImageList(int selectedGameIndex) {

        for (int i = 0; i < imageList.Count; i++) {

            if (i < selectedGameIndex) {

                imageList[i].GetComponent<Image>().material = otherScreenshot;
                imageList[i].move(new Vector3(imagePosition.transform.position.x, imagePosition.transform.position.y + (GRID_Y_OFFSET * (selectedGameIndex - i)), imagePosition.transform.position.z), new Vector3(smallScale, smallScale, smallScale));
            }
            else if (i == selectedGameIndex) {

                imageList[i].GetComponent<Image>().material = currentScreenshot;
                imageList[i].move(new Vector3(imagePosition.transform.position.x, imagePosition.transform.position.y, imagePosition.transform.position.z), new Vector3(1, 1, 1));
            }
            else if (i > selectedGameIndex) {

                imageList[i].GetComponent<Image>().material = otherScreenshot;
                imageList[i].move(new Vector3(imagePosition.transform.position.x, imagePosition.transform.position.y - (GRID_Y_OFFSET * (i - selectedGameIndex)), imagePosition.transform.position.z), new Vector3(smallScale, smallScale, smallScale));
            }
        }

        moving = true;
    }
}
