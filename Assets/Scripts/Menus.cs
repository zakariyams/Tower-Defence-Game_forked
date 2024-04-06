using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menus : MonoBehaviour
{


    [SerializeField] Animator anime;

    private bool isMenuOpen = true;



    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        anime.SetBool("MenuOpen", isMenuOpen);
    }  


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
