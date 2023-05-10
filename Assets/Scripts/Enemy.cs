using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public string type; // The name of the enemy
    public int hp; // How much health the enemy has
    public int dps; // How much damage the enemy deals per second
    public int speed; // How quickly the enemy moves
    public int value; // How much money the enemy drops upon defeat

    private NavMeshAgent agent; // Nav Mesh Agent of the Enemy

    void Start() {
        agent = GetComponent<NavMeshAgent>(); // Get the NavMesh Agent
        GameObject goal = GameObject.FindGameObjectWithTag("EnemyGoal"); // Find the King Square
        agent.SetDestination(goal.transform.position); // Target the King Square
    } // void Start

    void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Obstruction") {
            StartCoroutine(Attack(other.gameObject)); // Start attacking the Blocker
        } // if (Something is blocking the path)
        StopCoroutine(Attack(other.gameObject));

        if (other.collider.tag == "Anvil") {
            hp = 0;
        } // if (Crushed by an anvil)
    } // void OnCollisionEnter

    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Collider>().tag == "EnemyGoal") {
            Debug.Log("You just lost The Game");
        } // if (Reached the King Square)
    }

    IEnumerator Attack(GameObject target) {
        if (target.TryGetComponent<Blocker>(out Blocker blocker)) {
            for (int wall = target.GetComponent<Blocker>().hp; wall > 0; wall -= dps) {
                target.GetComponent<Blocker>().hp -= dps;
                yield return new WaitForSeconds(1f);
            } // Decrease the Blocker's HP by 1 DPS every second until its HP is 0
        } // target is a Blocker (or at least has a Blocker script)
        else{
            yield return null;
        } // else
    } // IEnumerator Attack

    // Update is called once per frame
    void Update() {
        if (hp < 1 && type != "triplets") {
            Destroy(gameObject);
        } // if (any enemy other than Triplets' HP is less than 1)
    } // + void Update
} // + class Enemy
