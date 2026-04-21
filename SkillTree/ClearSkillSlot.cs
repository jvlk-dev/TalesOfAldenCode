using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* ClearSkillSlot class for clearing the skill slot
*/
public class ClearSkillSlot : MonoBehaviour
{
    [SerializeField] private SkillSlot skillSlot;

    /**
    * ClearSlot method to handle clearing the skill slot
    * Destroys the child gameObject
    * @return void
    */
    public void ClearSlot()
    {
        if (skillSlot.transform.childCount > 0)
        {
            skillSlot.isFull = false;
            skillSlot.skillInSlot = 0;
            foreach (Transform child in skillSlot.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
