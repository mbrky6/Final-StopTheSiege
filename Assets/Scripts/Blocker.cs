using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour {
    public int hp;
    public AudioClip blocker;
    AudioSource source;
    Tile front; // The tile directly in front of the Blocker
    int currentHp; // Current HP of the Blocker

    // Start is called before the first frame update
    void Start() {
        source = GetComponent<AudioSource>();
        currentHp = hp;
    } // void Start

    // Update is called once per frame
    void Update() {
        if (hp < 1) {
            AudioSource.PlayClipAtPoint(blocker, Camera.main.transform.position);
            Destroy(gameObject);
        } // if (HP is less than 1)

        if (hp < currentHp) {
            source.Play();
            currentHp = hp;
        } // if (HP has decreased)
    } // void Update
} // + class Blocker
