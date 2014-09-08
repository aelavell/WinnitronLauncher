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
    int currentGameIndex = 0;
    Coroutine<_> moveThroughList;

    List<GameLabel> labelList;
    int selectedLabelIndex = 0;

    public Text gameLabelPrefab;
    public float GRID_Y_OFFSET = 60;

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

        //if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.I)) Move(-1);

        //else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.K)) Move(1);

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.M)) {
            // only able choose the game if we're not currently moving through the game list
            if (moveThroughList == null) {
                Runner.Instance.Run(playlist[currentGameIndex]);
            }
        }
    }

    void CreateLabels() {

        foreach (Game game in playlist) {

            var label = Instantiate(gameLabelPrefab) as Text;
            label.text = game.name;            
            label.transform.parent = transform;
            
            labelList.Add(label.GetComponent<GameLabel>());
        }

        sortLabelList();
    }

    void sortLabelList() {

        // Move and scale currently selected label        
        labelList[selectedLabelIndex].move(labelSelected.transform.position, 36);

        // Move all labels above it, starting with the closest
        var index = selectedLabelIndex - 1;
        var startIndex = index;
        while (index >= 0) {

            labelList[index].move(new Vector3(labelAbove.transform.position.x, labelAbove.transform.position.y + (GRID_Y_OFFSET * (startIndex - index)), labelAbove.transform.position.z), 36);
            index--;
        }
    }
}