using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager main;

    [Header("References")]
    [SerializeField] private GameObject[] towerPrefabs;

    private int selectedTower = 0;


    // Start is called before the first frame update
    private void Start()
    {

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

