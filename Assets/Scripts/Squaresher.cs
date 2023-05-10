using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squaresher : MonoBehaviour {
    public AudioClip anvil;
    AudioSource source;
    private GameObject sensor; // Tile directly beneath the Squaresher

    // Start is called before the first frame update
    void Start() {
        source = GetComponent<AudioSource>();
        RaycastHit hit;
        Ray view = new Ray(transform.position, -transform.up);

        if (Physics.Raycast(view, out hit)) {
            sensor = hit.transform.gameObject; // Attach the Sensor to the Squaresher
            sensor.AddComponent<Sensor>();
            sensor.GetComponent<Sensor>().anvil = this.gameObject; // Attach the Squaresher to the Sensor
        } // if (The view ray hits a tile underneath it)
    } // void Start

    void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Enemy") {
            AudioSource.PlayClipAtPoint(anvil, Camera.main.transform.position);
        } // if (touching an enemy)
    } // void OnCollisionEnter

    public virtual void Fall() {
        GetComponent<Rigidbody>().useGravity = true; // Turn on gravity
        GetComponent<Rigidbody>().AddForce(0, -2000, 0, ForceMode.Acceleration); // Throw the Squaresher down harder
    } // + virtual void Fall

} // + class Squaresher
