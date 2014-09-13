using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Jukebox : MonoBehaviour {

    public Text artistName;
    public Text songName;


    private Song[] songs;

    private int currentTrack;
    private int fadeOutTrack = 99;

    private float fadeOutTime = 0;


    void Start() {

        songs = GetComponentsInChildren<Song>();

        currentTrack = Random.Range(0, songs.Length);
        audio.clip = songs[currentTrack].clip;
        audio.Play();

        initWdiget();
    }

    void Update() {

        if (Input.GetKeyUp(KeyCode.J))
            lastTrack();
        if (Input.GetKeyUp(KeyCode.L))
            nextTrack();        
    }

    public void nextTrack() {
        
        audio.Stop();

        if (currentTrack >= songs.Length - 1)
            currentTrack = 0;
        else
            currentTrack++;

        audio.clip = songs[currentTrack].clip;
        audio.Play();
        initWdiget();
    }

    public void lastTrack() {

        audio.Stop();

        if (currentTrack <= 1)
            currentTrack = songs.Length - 1;
        else
            currentTrack--;

        audio.clip = songs[currentTrack].clip;
        audio.Play();
        initWdiget();
    }

    public void initWdiget() {

        songName.text = songs[currentTrack].name;
        artistName.text = songs[currentTrack].author;
    }
}
