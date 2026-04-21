using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* QuestController class for handling quest interaction
*/
public class QuestController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject questGiver;
    [SerializeField] private GameObject questMenu;
    [SerializeField] private GameObject activeQuest;
    [SerializeField] private GameObject HUD;

    public bool activeQuests = false;

    /**
    * Accept method for setting the activeQuest UI active and resuming time
    * @return void
    */
    private void Accept()
    {
        activeQuest.SetActive(true);
        HUD.SetActive(true);
        questMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        activeQuests = true;
    }

    /**
    * Reject method to setting the activeQuest UI inactive and resuming time
    * @return void
    */
    private void Reject()
    {
        questMenu.SetActive(false);
        HUD.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        activeQuests = false;
    }

    /**
    * QuestCompleted method for handling the completion quest
    * @return void
    */
    public void QuestCompleted()
    {
        activeQuest.SetActive(false);
    }
}
