using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Class for handling the specific spell behaviour
*/
public class LightningBolt : MonoBehaviour
{
    public int Identification = 10;
    private float life = 3;
    [Header("Stats")]
    public float lightningBoltSpeed = 10f;
    public float lightningBoltDamage = 10f;
    public static bool hasLightningBoltUnlocked = false;
    public float manaCost = 10f;

    [SerializeField] public int lightningBoltLVL = 0;
    
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
            var lightningBoltDamageLVL = lightningBoltDamage * lightningBoltLVL;
            var lightningProficiency = lightningBoltDamageLVL * playerStats.PlayerLightningProficiency;
            var magicPower = lightningBoltDamageLVL * playerStats.PlayerMagicPower;
            var lightningBoltTotalDamage = lightningBoltDamageLVL + lightningProficiency + magicPower;
            enemyController.TakeDamageFromMagic(lightningBoltTotalDamage);
            playerStats.PlayerMagicIncrease(0.003f);
            playerStats.PlayerLightningProficiencyIncrease(0.006f);
        }
        Destroy(gameObject);
    }
}