using UnityEngine;

public class BuildManager : MonoBehaviour{

    public static BuildManager instance;

    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject standardBlockerPrefab;

    void Start ()
    {
        blockertoBuild = standardBlockerPrefab;
    }

    private GameObject blockertoBuild;

    public GameObject GetBlockerToBuild ()
    {
        return blockertoBuild;
    }

}
