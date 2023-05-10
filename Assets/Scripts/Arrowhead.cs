using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrowhead : MonoBehaviour {
    
    void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Obstruction") {
            this.gameObject.GetComponent<Enemy>().hp = 0;
        } // if (Something is blocking the path)
    } // void OnCollisionEnter
} // + class Arrowhead
