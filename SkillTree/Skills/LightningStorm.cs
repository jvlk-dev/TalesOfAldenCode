using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Class for handling the specific spell behaviour
*/
public class LightningStorm : MonoBehaviour
{
    public int Identification = 12;
    private float life = 8;
    [Header("Stats")]
    // Speed
    public float lightningStormDamage = 0.5f;
    public static bool hasLightningStormUnlocked = false;
    public float manaCost = 10f;
    public int lightningStormLVL = 0;

    private PlayerStats playerStats;

    private float damageInterval = 1f;
    private List<EnemyController> enemiesInside;

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
            var lightningStormDamageLVL = lightningStormDamage * lightningStormLVL;
            var lightningProficiency = lightningStormDamageLVL * playerStats.PlayerLightningProficiency;
            var magicPower = lightningStormDamageLVL * playerStats.PlayerMagicPower;
            var lightningStormTotalDamage = lightningStormDamageLVL + lightningProficiency + magicPower;
            enemyController.TakeDamageFromMagic(lightningStormTotalDamage);
            Debug.Log(lightningStormTotalDamage);
            playerStats.PlayerMagicIncrease(0.0025f);
            playerStats.PlayerLightningProficiencyIncrease(0.005f);
        }
    }
}