using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {
    AudioSource source; // Audio Source
    public AudioClip click; // Audio Clip

    void Start() {
        source = GetComponent<AudioSource>();
    } // void Start

    public void StartBtn() {
        // Load the game
        source.PlayOneShot(click);
        SceneManager.LoadScene("GameStage");
    } // void StartBtn

    public void HomeBtn() {
        // Load the title screen
        source.PlayOneShot(click);
        SceneManager.LoadScene("TitleScreen");
    } // void StartBtn

    public void QuitBtn() {
        // Close the game
        source.PlayOneShot(click);
        Application.Quit();
    } // void QuitBtn
} // class TitleScreen
