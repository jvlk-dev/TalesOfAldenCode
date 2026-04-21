using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* PlayerManaManager class for handling player mana
*/
public class PlayerManaManager : MonoBehaviour
{
    [Header("Stats")]
    public float MaxMana = 100f;
    [SerializeField] private float manaRegenRate = 1f;
    [SerializeField] private float currentMana;
    private float regenTimer;

    /**
    * CurrentMana property
    * @return currentMana
    * @param value
    */
    public float CurrentMana
    {
        get { return currentMana; }
        set { currentMana = value;
                if (currentMana > MaxMana)
                {
                    currentMana = MaxMana;
                }
            }
    }

    [Header("Controllers")]
    [SerializeField] private PlayerStats playerStats;

    private void Start()
    {
        currentMana = MaxMana;
    }

    private void Update()
    {
        MaxMana = 100f + 20f * playerStats.PlayerMagicPower;

        regenTimer += Time.deltaTime;

        if (currentMana < MaxMana && regenTimer >= 1f)
        {
            currentMana = Mathf.Min(currentMana + manaRegenRate, MaxMana);
            regenTimer = 0f;
        }
    }

    /**
    * PlayerUsesMana method to handle the usage of mana
    * @param manaUsage from mana usage source
    * @return void
    */
    public void PlayerUsesMana(float manaUsage)
    {
        currentMana -= manaUsage;
        regenTimer = 0f;
    }
}