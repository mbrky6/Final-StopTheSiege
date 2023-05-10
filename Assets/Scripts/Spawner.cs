using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject basic; // Basic Triange prefab
    public GameObject arrowhead; // Arrowhead prefab
    public GameObject triplets; // Triplets prefab
    public GameObject tritone; // Tritone prefab
    public bool over = false;

    List<int> enemies = new List<int>() {0, 0, 0, 0, 3, 0, 2, 0, 3, 0, 0, 1, 3, 2, 1};

    float delay = 3f; // Time between enemy spawns
    Vector3 onTop; // Position on top of the selected tile


    // Start is called before the first frame update
    void Start() {
        onTop = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
        StartCoroutine(Cycle());
    } // void Start

    IEnumerator Cycle() {
        foreach(int i in enemies) {
            switch(i) {
                case 0:
                    Instantiate(basic, onTop, new Quaternion(0,0,0,0));
                    break;
                case 1:
                    Instantiate(arrowhead, onTop, new Quaternion(0,0,0,0));
                    break;
                case 2:
                    Instantiate(triplets, onTop, new Quaternion(0,0,0,0));
                    break;
                case 3:
                    Instantiate(tritone, onTop, new Quaternion(0,0,0,0));
                    break;
                default:
                    break;
            } // switch (i)

            yield return new WaitForSeconds(delay);
        } // foreach (int i in list of enemies)
        over = true;
        yield return null;
    } // IEnumerator Cycle

    void Update() {
        if (over) {
            StopCoroutine(Cycle());
        } // if (last enemy spawned)
    } // void Update


} // + class Spawner
