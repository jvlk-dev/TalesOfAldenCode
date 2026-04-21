using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* PlayerStats class for handling player stats
*/
public class PlayerStats : MonoBehaviour
{
    // Basic player statistics
    [Header("Basics")]
    public float PlayerMoveSpeed = 5f;
    public int PlayerXP = 1;

    // Player power statistics
    [Header("Powers")]
    public float PlayerMagicPower = 0.0f;
    public float PlayerFireProficiency = 0.0f;
    public float PlayerWindProficiency = 0.0f;
    public float PlayerWaterProficiency = 0.0f;
    public float PlayerLightningProficiency = 0.0f;
    public float PlayerStrenght = 1f;

    // Player's gold
    [Header("Gold")]
    public float Gold = 100f;

    /**
    * Increases the player's strength by the specified amount.
    * @param amount The amount by which to increase the player's strength.
    */
    public void PlayerStrenghtIncrease(float amount)
    {
        PlayerStrenght += amount;
    }

    /**
    * Increases the player's magic power by the specified amount.
    * @param amount The amount by which to increase the player's magic power.
    */
    public void PlayerMagicIncrease(float amount)
    {
        PlayerMagicPower += amount;
    }

    /**
    * Increases the player's fire proficiency by the specified amount.
    * @param amount The amount by which to increase the player's fire proficiency.
    */
    public void PlayerFireProficiencyIncrease(float amount)
    {
        PlayerFireProficiency += amount;
    }

    /**
    * Increases the player's wind proficiency by the specified amount.
    * @param amount The amount by which to increase the player's wind proficiency.
    */
    public void PlayerWindProficiencyIncrease(float amount)
    {
        PlayerWindProficiency += amount;
    }

    /**
    * Increases the player's water proficiency by the specified amount.
    * @param amount The amount by which to increase the player's water proficiency.
    */
    public void PlayerWaterProficiencyIncrease(float amount)
    {
        PlayerWaterProficiency += amount;
    }

    /**
    * Increases the player's lightning proficiency by the specified amount.
    * @param amount The amount by which to increase the player's lightning proficiency.
    */
    public void PlayerLightningProficiencyIncrease(float amount)
    {
        PlayerLightningProficiency += amount;
    }

    /**
    * Increases the player's gold by the specified amount.
    * @param amount The amount by which to increase the player's gold.
    */
    public void GiveQuestReward(float amount)
    {
        Gold += amount;
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
