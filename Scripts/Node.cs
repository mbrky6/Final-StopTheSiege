using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour {

    public Color hoverColor;

    private GameObject blocker;

    private Renderer rend;
    private Color startColor;

    void OnMouseDown()
    {
        if (blocker != null)
        {
            Debug.Log("cant build there! - TODO: Display on screen");
            return;
        }

        GameObject blockertoBuild = BuildManager.instance.GetBlockerToBuild();
        blocker = (GameObject)Instantiate(blockertoBuild, transform.position, transform.rotation);

    }
    
    void OnMouseEnter ()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit ()
    {
        rend.material.color = startColor;
    }

} 