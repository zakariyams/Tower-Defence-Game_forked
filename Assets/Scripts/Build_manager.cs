using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager main;

    [Header("References")]
    [SerializeField] private GameObject[] towerPrefabs;

    //private int selectedTower = 0;
    public int selectedTower = 0;

    // Start is called before the first frame update
    private void Start()
    {

    }

    //just used for testing
    public void Set_prefabs(GameObject prefab, int n)
    {
        towerPrefabs[n] = prefab;
    }

    //used to acces the static member main from other classes for example for testing
    public static BuildManager acces_build
    {
        get
        {
            // If no instance exists, find one or create one
            if (main == null)
            {
                main = FindObjectOfType<BuildManager>();
                if (main == null)
                {
                    GameObject singletonObject = new GameObject("BuildManagerSingleton");
                    main = singletonObject.AddComponent<BuildManager>();
                }
            }
            return main;
        }
    }


    // Update is called once per frame
    private void Update()
    {

    }


    private void Awake()
    {
        main = this;
    }



    public GameObject GetTower()
    {
        return towerPrefabs[selectedTower];
    }


    public void SetTower(int selected_index)
    {
        selectedTower = selected_index;
    }


}

