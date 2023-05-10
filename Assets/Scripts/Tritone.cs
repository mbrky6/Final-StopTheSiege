using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This entire script doesn't actually do anything
public class Tritone : MonoBehaviour {
    AudioSource source;
    
    // Start is called before the first frame update
    void Start() {
        source = GetComponent<AudioSource>();
        Invoke("Ding", 1);
    } // void Start

    void Ding() {
        source.Play();
        Invoke("Ding", 1);
    } // void Ding
} // + class Tritone
