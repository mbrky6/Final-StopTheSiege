using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class King : MonoBehaviour {
    public GameObject spawner; // Enemy spawner

    void GameWon() {
        SceneManager.LoadScene("EndScreen");
    } // void GameWon

    void GameLost() {
        SceneManager.LoadScene("LoseScreen");
    } // void GameLost

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy") {
            Invoke("GameLost", 1);
        } // if (an Enemy has reached the King)
    } // void OnTriggerEnter

    // Update is called once per frame
    void Update() {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 1 && spawner.GetComponent<Spawner>().over) {
            Invoke("GameWon", 1);
        } // if (no more Enemies on screen or spawning in)
    } // void Update
} // + class King
