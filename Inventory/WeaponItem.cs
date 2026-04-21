using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**
* WeaponItem class for handling quest update
*/
public class WeaponItem : MonoBehaviour
{
    [SerializeField] private GameObject activeQuest;
    [SerializeField] private QuestGiver questGiver;
    [SerializeField] private WeaponController weaponController;

    [SerializeField] private MenuController menuController;

    [SerializeField] private GameObject questMenu;

    [SerializeField] private TMP_Text Objective;
    [SerializeField] private TMP_Text Reward;

    [SerializeField] private TMP_Text ActiveObjective;
    [SerializeField] private TMP_Text ActiveReward;

    [SerializeField] private GameObject HUD;

    [SerializeField] private QuestController questController;
    
    /**
    * OnCollisionEnter method for updating the text content if conditions are true
    * @return void
    */
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" && activeQuest.activeSelf && questGiver.firstQuestCompleted && questController.activeQuests)
        {
            questGiver.secondQuestCompleted = true;

            Objective.text = "Find the object of your revenge deep inside the place where they come from";
            ActiveObjective.text = "Find the object of your revenge deep inside the place where they came from";
            ActiveReward.text = "";
            Reward.text = "";

            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            weaponController.canAttack = false;

            HUD.SetActive(false);
            questMenu.SetActive(true);
        }
    }
}
