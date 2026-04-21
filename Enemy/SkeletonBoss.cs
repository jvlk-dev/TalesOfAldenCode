using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* SkeletonBoss class for boss destruction
*/
public class SkeletonBoss : MonoBehaviour
{
    [SerializeField] private EnemyController enemyController;

    [SerializeField] private GameObject victoryScreen;

    [SerializeField] private MenuController menuController;

    [SerializeField] private GameObject hud;

    void Update()
    {
        if (enemyController.EnemyHealth <= 0f)
        {   
            //questController.QuestCompleted();
            StartCoroutine(BossDestruction());
        }
    }

    IEnumerator BossDestruction()
    {
        yield return new WaitForSeconds(5);
        menuController.PauseGame();
        hud.SetActive(false);
        victoryScreen.SetActive(true);
    }
}