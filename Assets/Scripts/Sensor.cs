using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour {
    public GameObject anvil;

    // Update is called once per frame
    void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Enemy") {
            anvil.GetComponent<Squaresher>().Fall();
        } // if (an enemy touches the sensor)

        if (other.collider.tag == "Anvil") {
            Destroy(anvil);
            Destroy(this); // Removes the Sensor script from the object
        } // if (Squaresher touches the sensor)
    } // void OnCollisionEnter
} // + class Sensor
