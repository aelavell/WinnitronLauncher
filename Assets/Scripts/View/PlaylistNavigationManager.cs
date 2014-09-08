/*
 * All labels move at once when moving through the grid. The selected label is placed in the middle and scaled up. Labels above and below the selected label are placed
 * relative to that label and are then placed either above of below that
 */ 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlaylistNavigationManager : Singleton<PlaylistNavigationManager> {

    List<Game> playlist;    
    Coroutine<_> moveThroughList;

    List<GameLabel> labelList;
    int selectedLabelIndex = 1;

    public bool moving { get; set; }

    public Text gameLabelPrefab;
    public float GRID_Y_OFFSET = 60;
    
    public float smallSize;   

    // The fixed positions of labels, all other labels are placed relative to these
    public GameObject labelAbove;
    public GameObject labelSelected;
    public GameObject labelBelow;

    void Start() {

        labelList = new List<GameLabel>();

        playlist = GameRepository.Instance.games;        

        CreateLabels();
        
    }

    void Update() {

        // Keyboard, move up and down through the current playlist
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.I)) {

            if (selectedLabelIndex == 0)
                selectedLabelIndex = labelList.Count - 1;
            else
                selectedLabelIndex--;

            sortLabelList();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.K)) {

            if (selectedLabelIndex >= labelList.Count - 1)
                selectedLabelIndex = 0;
            else
                selectedLabelIndex++;

            sortLabelList();
        }

        // Launch game
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.M)) {
            // only able choose the game if we're not currently moving through the game list
            if (moveThroughList == null) {
                Runner.Instance.Run(playlist[selectedLabelIndex]);
            }
        }
    }

    void CreateLabels() {

        foreach (Game game in playlist) {

            var label = Instantiate(gameLabelPrefab) as Text;
            label.text = game.name;            
            label.transform.parent = transform;
            
            label.GetComponent<GameLabel>().playlistNavMan = this;

            labelList.Add(label.GetComponent<GameLabel>());
        }

        sortLabelList();
    }

    void sortLabelList() {        

        // Move and scale currently selected label        
        labelList[selectedLabelIndex].move(labelSelected.transform.position, Vector3.one);
        
        // Move all labels above it, starting with the closest
        var index = selectedLabelIndex - 1;
        var startIndex = index;
        
        while (index >= 0) {

            labelList[index].move(new Vector3(labelAbove.transform.position.x, labelAbove.transform.position.y + (GRID_Y_OFFSET * (startIndex - index)), labelAbove.transform.position.z), new Vector3(smallSize, smallSize, smallSize));
            index--;
        }

        // Move all labels below it, starting with the closest
        index = selectedLabelIndex + 1;
        startIndex = index;

        while (index < labelList.Count) {

            labelList[index].move(new Vector3(labelBelow.transform.position.x, labelBelow.transform.position.y - (GRID_Y_OFFSET * (index - startIndex)), labelBelow.transform.position.z), new Vector3(smallSize, smallSize, smallSize));
            index++;
        }

        moving = true;
    }
}