using UnityEngine;
using System;
using System.Diagnostics;
using System.Collections;

public class Runner : Singleton<Runner> {
	public void Run(Game game) {
		Process myProcess = new Process();
		myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
		myProcess.StartInfo.CreateNoWindow = true;
		myProcess.StartInfo.UseShellExecute = false;
		myProcess.StartInfo.FileName = game.executablePath;//"C:\\WINNITRON\\Games\\Canabalt\\Canabalt.exe";
		myProcess.EnableRaisingEvents = true;
		StartCoroutine(RunProcess(myProcess));
	}

	IEnumerator RunProcess(Process process){ 
		Screen.fullScreen = false;
		yield return new WaitForSeconds(1.0f);
		process.Start();
		process.WaitForExit();
		Screen.fullScreen = true;
	}
}

