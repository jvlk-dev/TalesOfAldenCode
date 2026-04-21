using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**
* QuestGiver class for handling quest content
*/
public class QuestGiver : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject questMenu;
    [SerializeField] public GameObject activeQuest;
    [SerializeField] private GameObject HUD;

    [SerializeField] private TMP_Text Objective;
    [SerializeField] private TMP_Text Reward;

    [SerializeField] private TMP_Text ActiveObjective;
    [SerializeField] private TMP_Text ActiveReward;

    [SerializeField] private MenuController menuController;

    [SerializeField] private GameObject barrier;

    public bool firstQuestCompleted = false;
    public bool secondQuestCompleted = false;
    public bool thirdQuestCompleted = false;

    public bool startedQuestLine = false;

    private bool canOpenWindow = true;

    /**
    * OnTriggerEnter method for setting the quest menu active
    * Based on conditions sets the content for TMP texts
    * @return void
    */
    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "Player" && !activeQuest.activeSelf && canOpenWindow)
        {
            if (!firstQuestCompleted && !secondQuestCompleted && !thirdQuestCompleted)
            {
                Objective.text = "You: Excuse me, do you know anything about the skeletons that have been roaming around?\nStranger: Yes, I've heard about them roaming mostly around the passage between the two moutains down the road from village...";
                Reward.text = "Find out where the monsters are coming from.";
                ActiveObjective.text = "Find their origin";
                ActiveReward.text = "Look to the right side right before the passage between the two mountains";
                
            }
            if (firstQuestCompleted && !secondQuestCompleted && !thirdQuestCompleted)
            {
                Objective.text = "You: Do you happen to know where i could get a decent sword, I would like to replace this one of mine?\nStranger: Yes, I've heard that there should be a pretty decent sword near a well between the two mountains...";
                Reward.text = "Find the sword near a well between the two passages.";
                ActiveObjective.text = "Find a better sword";
                ActiveReward.text = "Look for a sword in the passage between the two mountains";
            }
            
            startedQuestLine = true;
            questMenu.SetActive(true);
            HUD.SetActive(false);
            menuController.PauseGame();
            menuController.questMenuOpened = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            canOpenWindow = false;
            StartCoroutine(ResetWindowCooldown());
        }
    }

    /**
    * ResetWindowCooldown method for reseting the window cooldown
    * Makes it so that player can't spam open window
    * @return void
    */
    IEnumerator ResetWindowCooldown()
    {
        yield return new WaitForSeconds(3);
        canOpenWindow = true;
        menuController.questMenuOpened = false;
        canOpenWindow = true;
    }

    /**
    * OK method for resuming the game
    * @return void
    */
    public void OK()
    {
        menuController.ResumeGame();
        menuController.questMenuOpened = false;
    }
}
