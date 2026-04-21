using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Class for handling the specific spell behaviour
*/
public class WaterWhirpool : MonoBehaviour
{
    public int Identification = 9;
    private float life = 10;
    [Header("Stats")]
    // Speed
    public float waterWhirpoolSpeed = 1f;
    public float waterWhirpoolDamage = 0.3f;
    public static bool hasWaterWhirpoolUnlocked = false;
    public float manaCost = 10f;
    public int waterWhirpoolLVL = 0;

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
            var waterWhirpoolDamageLVL = waterWhirpoolDamage * waterWhirpoolLVL;
            var waterProficiency = waterWhirpoolDamageLVL * playerStats.PlayerWaterProficiency * 0.1f;
            var magicPower = waterWhirpoolDamageLVL * playerStats.PlayerMagicPower * 0.1f;
            var waterWhirpoolTotalDamage = waterWhirpoolDamageLVL + waterProficiency + magicPower;
            enemyController.TakeDamageFromMagic(waterWhirpoolTotalDamage);
            Debug.Log(waterWhirpoolTotalDamage);
            playerStats.PlayerMagicIncrease(0.002f);
            playerStats.PlayerWaterProficiencyIncrease(0.004f);
        }
    }
}