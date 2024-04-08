using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position_script : MonoBehaviour
{


    [Header("References")]
    [SerializeField] private SpriteRenderer spriterend;
    [SerializeField] private Color hovcolour;

    private GameObject tower;
    private Color startcolour;



    // Start is called before the first frame update
    private void Start()
    {
        startcolour = spriterend.color;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        spriterend.color = hovcolour;
    }


    private void OnMouseExit()
    {
        spriterend.color = startcolour;
    }

    private void OnMouseDown()
    {
        Debug.Log(" " + name);

        if (tower != null )
        {
            return;
        }

        GameObject buildtower = BuildManager.main.GetTower();

        if (LevelManager.main.currency < 150)
        {
            Debug.Log("You can't afford this, get your money up!");
            return;
        }

        LevelManager.main.Spend(150);


        tower = Instantiate(buildtower, transform.position, Quaternion.identity);

    }

}
