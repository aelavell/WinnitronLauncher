/*
 * All labels move at once when moving through the grid. The selected label is placed in the middle and scaled up. Labels above and below the selected label are placed
 * relative to that label and are then placed either above of below that
 */ 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameNavigationManager : Singleton<GameNavigationManager> {    

    public GameObject gameLabelPrefab;
    public float GRID_Y_OFFSET = 60;

    public float smallScale;

    // The fixed positions of labels, all other labels are placed relative to these
    public GameObject labelAbove;
    public GameObject labelSelected;
    public GameObject labelBelow;

    public ScreenshotDisplayManager screenshotDisplayManager;

	public Animation UpArrow;
	public Animation DownArrow;

    public bool moving { get; set; }

    List<Game> playlist;    

    List<GameLabel> labelList;
    int selectedGameIndex = 0;
    bool waiting = false;


    void Start() {

        labelList = new List<GameLabel>();

        playlist = GameRepository.Instance.games;        

        CreateLabels();
        
    }

    void Update() {

        // Keyboard, move up and down through the current playlist
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            
            if (selectedGameIndex == 0)
                selectedGameIndex = labelList.Count - 1;
            else
                selectedGameIndex--;

            sortLabelList();
            screenshotDisplayManager.sortImageList(selectedGameIndex);

			UpArrow.Rewind ();
			UpArrow.Play ();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {

            if (selectedGameIndex >= labelList.Count - 1)
                selectedGameIndex = 0;
            else
                selectedGameIndex++;

            sortLabelList();
            screenshotDisplayManager.sortImageList(selectedGameIndex);

			DownArrow.Rewind ();
			DownArrow.Play ();
        }

        // Launch game
        if (!waiting && (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.X) || Input.GetKeyUp(KeyCode.N) || Input.GetKeyUp(KeyCode.M))) {

            waiting = true; StartCoroutine("wait"); // So that the user can't launch multiple games at once
            Runner.Instance.Run(playlist[selectedGameIndex]);            
        }
    }

    void CreateLabels() {

        foreach (Game game in playlist) {

            var label = Instantiate(gameLabelPrefab) as GameObject;
			label.GetComponent<GameLabel>().renameLabel(game.name);
            label.transform.parent = transform;
            
            label.GetComponent<GameLabel>().gameNavMan = this;

            labelList.Add(label.GetComponent<GameLabel>());
        }

        sortLabelList();
    }

    void sortLabelList() {        

        // Move and scale currently selected label        
        labelList[selectedGameIndex].move(labelSelected.transform.position, Vector3.one);
		labelList[selectedGameIndex].setAlpha(1);
		labelList[selectedGameIndex].selected = true;
        
        // Move all labels above it, starting with the closest
        var index = selectedGameIndex - 1;
        var startIndex = index;
        
        while (index >= 0) {

            labelList[index].move(new Vector3(labelAbove.transform.position.x, labelAbove.transform.position.y + (GRID_Y_OFFSET * (startIndex - index)), labelAbove.transform.position.z), new Vector3(smallScale, smallScale, smallScale));

			//Fade Text as they move away from the selection
			labelList[index].setAlpha(0.5f - (Mathf.Abs (startIndex - index) * 0.1f));

			labelList[index].selected = false;
            
			index--;
        }

        // Move all labels below it, starting with the closest
        index = selectedGameIndex + 1;
        startIndex = index;

        while (index < labelList.Count) {

            labelList[index].move(new Vector3(labelBelow.transform.position.x, labelBelow.transform.position.y - (GRID_Y_OFFSET * (index - startIndex)), labelBelow.transform.position.z), new Vector3(smallScale, smallScale, smallScale));

			//Fade Text as they move away from the selection
			labelList[index].setAlpha(0.5f - (Mathf.Abs (startIndex - index) * 0.1f));

			labelList[index].selected = false;

            index++;
        }

        moving = true;
    }

    IEnumerator wait() {

        yield return new WaitForSeconds(1);
        waiting = false;
    }
}