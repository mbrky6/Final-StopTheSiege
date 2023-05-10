using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerBuild : MonoBehaviour
{
    public GameObject Blocker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void whenButtonClicked()
    {
        if (Blocker.activeInHierarchy == false)
            Blocker.SetActive(true);
        else
            Blocker.SetActive(false);
    }
}
