using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Class for handling the specific spell behaviour
*/
public class FireZone : MonoBehaviour
{
    public int Identification = 2;
    private float life = 8;
    [Header("Stats")]
    // Speed
    public float fireZoneDamage = 0.5f;
    public static bool hasFireZoneUnlocked = false;
    public float manaCost = 10f;
    public int fireZoneLVL = 0;

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
            var fireZoneDamageLVL = fireZoneDamage * fireZoneLVL;
            var fireProficiency = fireZoneDamageLVL * playerStats.PlayerFireProficiency;
            var magicPower = fireZoneDamageLVL * playerStats.PlayerMagicPower;
            var fireZoneTotalDamage = fireZoneDamageLVL + fireProficiency + magicPower;
            enemyController.TakeDamageFromMagic(fireZoneTotalDamage);
            Debug.Log(fireZoneTotalDamage);
            playerStats.PlayerMagicIncrease(0.002f);
            playerStats.PlayerFireProficiencyIncrease(0.004f);
        }
    }
}