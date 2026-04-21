using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* PlayerManaBar class for handling player mana bar
*/
public class PlayerManaBar : MonoBehaviour
{
    private Image ManaBar;
    private PlayerManaManager playerManaManager;

    private void Start()
    {
         ManaBar = GetComponent<Image>();
         playerManaManager = FindObjectOfType<PlayerManaManager>();
    }

    /**
    * Update method to handle updating the fill amount of UI image
    * @return void
    */
    void Update()
    {
        ManaBar.fillAmount = playerManaManager.CurrentMana / playerManaManager.MaxMana;
    }
}
