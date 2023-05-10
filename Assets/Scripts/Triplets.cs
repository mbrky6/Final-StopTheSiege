using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triplets : MonoBehaviour {
    [SerializeField] GameObject basic; // Basic Triangle prefab
    bool killedByAnvil = false; // Was this enemy killed by an anvil?
    
    void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Anvil") {
            killedByAnvil = true;
        } // if (crushed by an anvil)
    } // void OnCollisionEnter

    void Update() {
        if (GetComponent<Enemy>().hp < 1 && !killedByAnvil) {
            for (int i = 0; i < 3; i++) {
                Instantiate(basic, transform.position, new Quaternion(0,0,0,0));
            } // for (3 times)
            Destroy(gameObject);
        } // if (killed by any means other than an anvil)
        if (killedByAnvil) {
            Destroy(gameObject);
        } // if (killed by anvil)
    } // void Update
} // + class Triplets
