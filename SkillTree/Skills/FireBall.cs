using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/**
* Class for handling the specific spell behaviour
*/
public class FireBall : MonoBehaviour
{
    public int Identification = 1;
    private float life = 3;
    [Header("Stats")]
    public float fireBallSpeed = 10f;
    public float fireBallDamage = 10f;
    public static bool hasFireBallUnlocked = false;
    public float manaCost = 10f;

    [SerializeField] public int fireBallLVL = 0;
    
    private PlayerStats playerStats;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    void Awake()
    {
        Destroy(gameObject, life);
    }
    
    /**
    * Method for handling the specific spell damage and behaviour
    */
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            EnemyController enemyController = col.gameObject.GetComponent<EnemyController>();
            var fireBallDamageLVL = fireBallDamage * fireBallLVL;
            var fireProficiency = fireBallDamageLVL * playerStats.PlayerFireProficiency;
            var magicPower = fireBallDamageLVL * playerStats.PlayerMagicPower;
            var fireBallTotalDamage = fireBallDamageLVL + fireProficiency + magicPower;
            enemyController.TakeDamageFromMagic(fireBallTotalDamage);
            playerStats.PlayerMagicIncrease(0.003f);
            playerStats.PlayerFireProficiencyIncrease(0.006f);
        }
        Destroy(gameObject);
    }
}