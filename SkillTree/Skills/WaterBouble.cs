using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Class for handling the specific spell behaviour
*/
public class WaterBouble : MonoBehaviour
{
    public int Identification = 7;
    private float life = 3;
    [Header("Stats")]
    public float waterBoubleSpeed = 10f;
    public float waterBoubleDamage = 10f;
    public static bool hasWaterBoubleUnlocked = false;
    public float manaCost = 10f;

    [SerializeField] public int waterBoubleLVL = 0;
    
    private PlayerStats playerStats;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    void Awake()
    {
        Destroy(gameObject, life);
    }
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            EnemyController enemyController = col.gameObject.GetComponent<EnemyController>();
            var waterBoubleDamageLVL = waterBoubleDamage * waterBoubleLVL;
            var waterProficiency = waterBoubleDamageLVL * playerStats.PlayerWaterProficiency;
            var magicPower = waterBoubleDamageLVL * playerStats.PlayerMagicPower;
            var waterBoubleTotalDamage = waterBoubleDamageLVL + waterProficiency + magicPower;
            enemyController.TakeDamageFromMagic(waterBoubleTotalDamage);
            playerStats.PlayerMagicIncrease(0.003f);
            playerStats.PlayerWaterProficiencyIncrease(0.006f);
        }
        Destroy(gameObject);
    }
}