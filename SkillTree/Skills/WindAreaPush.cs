using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Class for handling the specific spell behaviour
*/
public class WindAreaPush : MonoBehaviour
{
    public int Identification = 6;
    private float life = 1;
    [Header("Stats")]
    // Speed
    public float windAreaPushSpeed = 5f;
    public float windAreaPushDamage = 1f;
    public static bool hasWindAreaPushUnlocked = false;
    public float manaCost = 10f;
    public int windAreaPushLVL = 0;

    private PlayerStats playerStats;

    private float damageInterval = 0.1f; // Time interval between damage ticks
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
            var windAreaPushDamageLVL = windAreaPushDamage * windAreaPushLVL;
            var windProficiency = windAreaPushDamageLVL * playerStats.PlayerWindProficiency * 0.1f;
            var magicPower = windAreaPushDamageLVL * playerStats.PlayerMagicPower * 0.1f;
            var windAreaPushTotalDamage = windAreaPushDamageLVL + windProficiency + magicPower;
            enemyController.TakeDamageFromMagic(windAreaPushTotalDamage);
            Debug.Log(windAreaPushTotalDamage);
            playerStats.PlayerMagicIncrease(0.002f);
            playerStats.PlayerWindProficiencyIncrease(0.004f);
        }
    }
}