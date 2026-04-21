using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/**
* Class for handling the specific spell behaviour
*/
public class FireBarrier : MonoBehaviour
{
    public int Identification = 3;
    private float life = 8;
    [Header("Stats")]
    // Speed
    public float fireBarrierDamage = 0.4f;
    public static bool hasFireBarrierUnlocked = false;
    public float manaCost = 20f;
    public int fireBarrierLVL = 0;

    private PlayerStats playerStats;

    private float damageInterval = 0.3f; // Time interval between damage ticks
    private List<EnemyController> enemiesInside; // List of enemies inside the fire zone

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        enemiesInside = new List<EnemyController>();
        InvokeRepeating("DealDamage", damageInterval, damageInterval);
    }

    void OnEnable()
    {
        StartCoroutine(DeactivateBarrier());
    }

    IEnumerator DeactivateBarrier()
    {
        yield return new WaitForSeconds(life);
        gameObject.SetActive(false);
        enemiesInside.Clear();
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
            if(gameObject.activeSelf)
            {
                var fireBarrierDamageLVL = fireBarrierDamage * fireBarrierLVL;
                var fireProficiency = fireBarrierDamageLVL * playerStats.PlayerFireProficiency * 0.1f;
                var magicPower = fireBarrierDamageLVL * playerStats.PlayerMagicPower * 0.1f;
                var fireBarrierTotalDamage = fireBarrierDamageLVL + fireProficiency + magicPower;
                enemyController.TakeDamageFromMagic(fireBarrierTotalDamage);
                Debug.Log(fireBarrierTotalDamage);
                playerStats.PlayerMagicIncrease(0.002f);
                playerStats.PlayerFireProficiencyIncrease(0.004f);
            }
        }
    }
}