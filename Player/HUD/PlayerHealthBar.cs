using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* PlayerHealthBar class for handling player health bar
*/
public class PlayerHealthBar : MonoBehaviour
{
    private Image HealthBar;
    private PlayerHealthManager playerHealthManager;

    private void Start()
    {
         HealthBar = GetComponent<Image>();
         playerHealthManager = FindObjectOfType<PlayerHealthManager>();
    }

    /**
    * Update method to handle updating the fill amount of UI image
    * @return void
    */
    void Update()
    {
        HealthBar.fillAmount = playerHealthManager.CurrentHealth / playerHealthManager.MaxHealth;
    }
}
