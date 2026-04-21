using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* WelcomeInfo class for handling the initial quest window
*/
public class WelcomeInfo : MonoBehaviour
{
    [SerializeField] private MenuController menuController;

    /**
    * Awake method for stopping the game at the start
    * @return void
    */
    void Awake()
    {
        menuController.PauseGame();
        menuController.questMenuOpened = true;
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
