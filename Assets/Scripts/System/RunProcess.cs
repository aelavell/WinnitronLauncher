using UnityEngine;
using System.Collections;

public class RunProcess : MonoBehaviour {
	void Start () {
		Debug.Log(Application.dataPath);
		System.Diagnostics.Process.Start(Application.dataPath + "HexFiend.app/Contents/Resources/MacOS/Hex Fiend");
	}
}

