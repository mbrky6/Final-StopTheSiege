using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musquareteer : MonoBehaviour {
    public AudioClip gunshot;
    AudioSource source;
    GameObject closestObject;

    void Start() {
        source = GetComponent<AudioSource>();
        Invoke("Shoot", 3);
    } // void Start

    // Determining which enemies are within its range
    void PickTarget(Vector3 center, float radius) {
        float oldDistance = 9999;
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (Collider c in hitColliders) {
            GameObject g = c.gameObject;
            float dist = Vector3.Distance(transform.position, g.transform.position);
            if (g.TryGetComponent<Enemy>(out Enemy e) && g.GetComponent<Enemy>().type == "tritone") {
                closestObject = g;
                break;
            } // if (the enemy is a Tritone)
            else if (dist < oldDistance && g.tag == "Enemy") {
                closestObject = g;
                oldDistance = dist;
            } // else if (the next gameObject is closer than the last and is also an enemy)
        } // foreach (Collider in hitColliders)
        if (closestObject != null) {
            transform.LookAt(new Vector3(closestObject.transform.position.x, transform.position.y, closestObject.transform.position.z));
        } // if (there is an enemy to look at)
    } // void PickTarget

    // Shoot attack
    void Shoot() {
        if (closestObject != null) {
            closestObject.GetComponent<Enemy>().hp -= GetComponent<Building>().damage;
            source.Play();
        } // if (an object is in range)
        Invoke("Shoot", 3); // Invoke it again, Sam!
    } // void Shoot

    // Update is called once per frame
    void Update() {
        PickTarget(this.transform.position, 10f);
        if (closestObject != null) {
            if (Vector3.Distance(transform.position, closestObject.transform.position) > 10) {
                closestObject = null;
            } // if (closest enemy out of range)
        } // if (there is a closest object)
    } // void Update
} // + class Musquareteer
