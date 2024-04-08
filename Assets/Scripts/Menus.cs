using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menus : MonoBehaviour
{


    [SerializeField] Animator anime;

    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;

    private bool isMenuOpen = true;



    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        anime.SetBool("MenuOpen", isMenuOpen);
    }  


    private void OnGUI()
    {
        currencyUI.text = LevelManager.main.currency.ToString();
    }


    public void SetSelected()
    {

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
