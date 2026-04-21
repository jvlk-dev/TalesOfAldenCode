using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Class for handling the specific spell behaviour
*/
public class LightningStrike : MonoBehaviour
{
    public int Identification = 11;
    private float life = 1;
    [Header("Stats")]
    // Speed
    public float lightningStrikeDamage = 5f;
    public static bool hasLightningStrikeUnlocked = false;
    public float manaCost = 10f;
    public int lightningStrikeLVL = 0;

    private PlayerStats playerStats;

    private float damageInterval = 1f; // Time interval between damage ticks
    private List<EnemyController> enemiesInside; // List of enemies inside the fire zone

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        enemiesInside = new List<EnemyController>();
        InvokeRepeating("DealDamage", damageInterval, damageInterval);
    }

    void Awake()
    {
        Destroy(gameObject,life);
    }

    /**
    * Method for handling the entry of collider
    */
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemyController = col.gameObject.GetComponent<EnemyController>();
            enemiesInside.Add(enemyController);
        }
    }

    /**
    * Method for handling the leave of collider
    */
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemyController = col.gameObject.GetComponent<EnemyController>();
            enemiesInside.Remove(enemyController);
        }
    }

    void DealDamage()
    {
        // Loop through all enemies inside the fire zone and deal damage to them
        foreach (EnemyController enemyController in enemiesInside)
        {
            var lightningStrikeDamageLVL = lightningStrikeDamage * lightningStrikeLVL;
            var lightningProficiency = lightningStrikeDamageLVL * playerStats.PlayerLightningProficiency;
            var magicPower = lightningStrikeDamageLVL * playerStats.PlayerMagicPower;
            var lightningStrikeTotalDamage = lightningStrikeDamageLVL + lightningProficiency + magicPower;
            enemyController.TakeDamageFromMagic(lightningStrikeTotalDamage);
            Debug.Log(lightningStrikeTotalDamage);
            playerStats.PlayerMagicIncrease(0.0025f);
            playerStats.PlayerLightningProficiencyIncrease(0.005f);
        }
    }
}