using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Barrier class for handling the barrier gamObject
*/
public class Barrier : MonoBehaviour
{
    [SerializeField] private QuestGiver questGiver;

    // Update is called once per frame
    void Update()
    {
        if (questGiver.secondQuestCompleted)
        {
            Destroy(gameObject);
        }
    }
}
