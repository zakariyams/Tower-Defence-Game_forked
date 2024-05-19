using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position_script : MonoBehaviour
{


    [Header("References")]
    [SerializeField] private SpriteRenderer spriterend;
    [SerializeField] private Color hovcolour;

    //private GameObject tower;
    public GameObject tower;
    private Color startcolour;
    //This variabe will only be used for testing
    //public GameObject mocktower;



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



    public void SetSpriteRenderer(SpriteRenderer spriteRenderer)
    {
        spriterend = spriteRenderer;
    }

    public void SetHoverColor(Color color)
    {
        hovcolour = color;
    }





    private void OnMouseExit()
    {
        spriterend.color = startcolour;
    }

    //Changed from private to public to make it accesable for tests/Z
    public void OnMouseDown()
    {
        //Debug.Log(" " + name);

        Debug.Log("Runs5");



        if (tower != null)
        {
            return;
        }
        
        Debug.Log("Runs6");
        GameObject buildtower = BuildManager.main.GetTower();

        if (LevelManager.main.currency < 150)
        {
            Debug.Log("You can't afford this, get your money up!");
            return;
        }

        LevelManager.main.Spend(150);

        Debug.Log("Bip");

        Debug.Log("Still running");

        if (buildtower == null)
        {
            Debug.Log("bu");
        }

        if (tower == null)
        {
            Debug.Log("t");
        }
    
        Debug.Log("ok");
        

        try {
            //tower = Instantiate(buildtower, transform.position, Quaternion.identity);
            Instantiate(buildtower, transform.position, Quaternion.identity);
            tower = buildtower;
            Debug.Log("Instantiate");
         }
        //tower = Instantiate(buildtower, transform.position, Quaternion.identity);
        catch(System.Exception e) {
            Debug.LogError("Error during instantiation: " + e.Message);
        }
        Debug.Log("Bop");

        
    }

}
