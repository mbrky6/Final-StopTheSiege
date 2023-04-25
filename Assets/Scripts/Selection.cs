using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selection : MonoBehaviour {

    public Material highlightMaterialYes; // Material of valid hovered object
    public Material highlightMaterialNo; // Material of invalid hovered object
    public Material selectedMaterial; // Material of selected object
    public string validType; // Current valid tile type

    private Material originalMaterialHighlight; // Original material of highlighted object
    private Material originalMaterialSelection; // Original material of selected object
    private bool valid; // Checks the validity of the hover (Not currently in use)
    private Transform highlight; // Transform for highlighting
    private Transform selection; // Transform for selecting
    private RaycastHit raycastHit; // Raycast to determine what is being pointed at

    // Update is called once per frame
    void Update() {
        // Returning to original Material
        if (highlight != null) {
            highlight.GetComponent<MeshRenderer>().material = originalMaterialHighlight;
            highlight = null;
        } // if (highlighted)

        // Highlighting
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Draw a ray from the mouse position
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit)) {
            highlight = raycastHit.transform;
            if (highlight.GetComponent<Tile>().type == validType) {
                valid = true;
            } // if (player type and highlighted tile type match)
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
                if (selection.GetComponent<MeshRenderer>().material != selectedMaterial) {
                    originalMaterialSelection = originalMaterialHighlight;
                    selection.GetComponent<MeshRenderer>().material = selectedMaterial;
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
