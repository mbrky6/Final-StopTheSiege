using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squaremurai : MonoBehaviour {
    AudioSource source;
    float lastSlash; // Time of last slash
    
    // Start is called before the first frame update
    void Start() {
        source = GetComponent<AudioSource>();
    } // void Start

    // Determine which enemies are within range, then attack them.
    void Slash(Vector3 center, float radius) {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (Collider c in hitColliders) {
            GameObject g = c.gameObject;
            if (g.TryGetComponent<Enemy>(out Enemy e)) {
                g.GetComponent<Enemy>().hp -= GetComponent<Building>().damage;

                if (g.GetComponent<Enemy>().type == "triplets") {
                    g.GetComponent<Enemy>().hp = 0;
                    source.Play();
                } // if (enemy is triplets)
            } // if (object is an enemy)
        } // foreach (Collider in hitColliders)
        lastSlash = Time.time;
    } // void Slash

    void Update() {
        if (Time.time > lastSlash + 1) {
            Slash(transform.position, 3f);
        } // if (1 second has passed since Squaremurai last attacked)
        float rZ = (0.8f * Time.time * 360);
        transform.rotation = Quaternion.Euler(0, rZ, 0);
    } // void Update
} // + class Squaremurai
