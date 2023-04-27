using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    public string type; // Type of building
    public string validTile; // Tile type the building can be placed on
    public int price; // Cost of the building
    public int range; // How many tiles out the building can attack or defend from
    public int damage; // How much damage the building deals per hit
    public int delay; // Time between hits

} // + class Building
