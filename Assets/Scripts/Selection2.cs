using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selection2 : MonoBehaviour {

    public Material highlightMaterialYes; // Material of valid hovered object
    public Material highlightMaterialNo; // Material of invalid hovered object
    public Material selectedMaterial; // Material of selected object
    public GameObject Squaremurai; // Squaremurai prefab
    public GameObject Musquareteer; // Musquareteer prefab
    public GameObject Blocker; // Blocker prefab
    public GameObject Squaresher; // Squaresher prefab

    public GameObject chosenBuilding; // Building currently chosen to be placed
    string validType; // Current valid tile type

    private Material originalMaterialHighlight; // Original material of highlighted object
    private Material originalMaterialSelection; // Original material of selected object
    private bool valid; // Checks the validity of the hover (Not currently in use)
    private Transform highlight; // Transform for highlighting
    private Transform selection; // Transform for selecting
    private Vector3 onTop; // Position on top of the selected tile
    private RaycastHit raycastHit; // Raycast to determine what is being pointed at

    // Update is called once per frame
    void Update() {
        // Checking the valid type of the selected building
        validType = chosenBuilding.GetComponent<Building>().validTile;

        // Returning to original Material
        if (highlight != null) {
            highlight.GetComponent<MeshRenderer>().material = originalMaterialHighlight;
            highlight = null;
        } // if (highlighted)

        // Highlighting
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Draw a ray from the mouse position
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit)) {
            highlight = raycastHit.transform;
            if (highlight.TryGetComponent<Tile>(out Tile tile)) {
                if (highlight.GetComponent<Tile>().type == validType) {
                    valid = true;
                } // if (player type and highlighted tile type match)
                else {
                    valid = false;
                } // else
            } // if (highlighted object is a tile)
            else {
                valid = false;
            } // else

            if (highlight.CompareTag("tile") && highlight != selection) {
                if (highlight.GetComponent<MeshRenderer>().material != highlightMaterialYes || highlight.GetComponent<MeshRenderer>().material != highlightMaterialNo) {
                    if (valid) {
                        originalMaterialHighlight = highlight.GetComponent<MeshRenderer>().material;
                        highlight.GetComponent<MeshRenderer>().material = highlightMaterialYes;
                    } // if (valid)
                    else {
                        originalMaterialHighlight = highlight.GetComponent<MeshRenderer>().material;
                        highlight.GetComponent<MeshRenderer>().material = highlightMaterialNo;
                    } // else
                } // if (highlighted object does not have the highlighted material)
            } // if (highlighted object is a tile and not selected)
            else {
                highlight = null;
            } // else
        } // if (mouse is over anything other than a tile)

        // Selecting
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            if (highlight && valid) {
                if (selection != null) {
                    selection.GetComponent<MeshRenderer>().material = originalMaterialSelection;
                } // if (object is selected)
                selection = raycastHit.transform;
                onTop = new Vector3(selection.position.x, selection.position.y + 0.3f, selection.position.z);
                if (selection.GetComponent<MeshRenderer>().material != selectedMaterial) {
                    originalMaterialSelection = originalMaterialHighlight;
                    selection.GetComponent<MeshRenderer>().material = selectedMaterial;

                    // Putting down the building
                    Collider[] intersecting = Physics.OverlapSphere(onTop, 0.01f, 3); // OverlapSphere detects if an object is inside of it
                    if (intersecting.Length == 0) {
                        if (chosenBuilding == Squaresher) {
                            onTop.y += 3;
                        } // if (Squaresher is selected)
                        Instantiate(chosenBuilding, onTop, new Quaternion(0,0,0,0));
                    } // if (Object already on that location)
                } // if (clicked object is a tile)
                highlight = null;
            } // if (the object is highlighted and valid)
            else {
                if (selection) {
                    selection.GetComponent<MeshRenderer>().material = originalMaterialSelection;
                    selection = null;
                } // if (object is selected)
            } // else
        } // if (highlighted object clicked)
    } // void Update
} // + class Selection
