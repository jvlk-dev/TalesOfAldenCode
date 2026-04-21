using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Class for handling the specific spell behaviour
*/
public class WindPush : MonoBehaviour
{
    public int Identification = 4;
    private float life = 1;
    [Header("Stats")]
    // Speed
    public float windPushSpeed = 50f;
    public float windPushDamage = 0.5f;
    public static bool hasWindPushUnlocked = false;
    public float manaCost = 10f;
    public int windPushLVL = 0;

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
            var windPushDamageLVL = windPushDamage * windPushLVL;
            var windProficiency = windPushDamageLVL * playerStats.PlayerWindProficiency * 0.1f;
            var magicPower = windPushDamageLVL * playerStats.PlayerMagicPower * 0.1f;
            var windPushTotalDamage = windPushDamageLVL + windProficiency + magicPower;
            enemyController.TakeDamageFromMagic(windPushTotalDamage);
            Debug.Log(windPushTotalDamage);
            playerStats.PlayerMagicIncrease(0.002f);
            playerStats.PlayerWindProficiencyIncrease(0.004f);
        }
    }
}