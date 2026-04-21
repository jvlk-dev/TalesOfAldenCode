using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* EnemyAttacks class to handle enemy attacking
*/
public class EnemyAttacks : MonoBehaviour
{

    [Header("Basics")]
    [SerializeField] public bool duringAttackAnimation = false;

    [Header("Controllers")]
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private PlayerHealthManager playerHealthManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && duringAttackAnimation)
        {
            playerHealthManager.PlayerTakesDamage(enemyController.EnemyStrenght);
        }
    }
}
