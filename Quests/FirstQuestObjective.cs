using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**
* FirstQuestObjective class for handling the first quest
*/
public class FirstQuestObjective : MonoBehaviour
{
    [SerializeField] private GameObject activeQuest;
    [SerializeField] private QuestGiver questGiver;
    [SerializeField] private GameObject questConclusion;
    [SerializeField] private GameObject hud;

    [SerializeField] private MenuController menuController;

    [SerializeField] private TMP_Text Conclusion;

    [SerializeField] private QuestController questController;

    /**
    * OnCollisionEnter method to handle the collision between this object and Player
    * @return void
    */
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" && activeQuest.activeSelf && !questGiver.firstQuestCompleted)
        {
            menuController.PauseGame();
            questGiver.firstQuestCompleted = true;
            Conclusion.text = "You found out where they are coming from, return to the village. If you want to get your revenge, you should get a better weapon.";
            questConclusion.SetActive(true);
            hud.SetActive(false);
            activeQuest.SetActive(false);
            questController.activeQuests = false;
        }
    }
}
