using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

/**
* DraggableSkill class for handling the draggable skill
*/
public class DraggableSkill : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public GameObject duplicatePrefab;

    public GameObject clone;
    public Transform cloneParent;

    public int spellID;

    [Header("Controllers")]
    [SerializeField] private SkillTreeController skillTreeController;

    /**
    * OnBeginDrag method to handle beggining the drag
    * Clones the original gameObject and moves the clone
    * @return void
    */
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(skillTreeController.unlockedSpells.Contains(spellID))
        {
            Debug.Log("Begin Drag");

            // Create the duplicate object
            clone = Instantiate(duplicatePrefab, transform.parent);
            clone.transform.position = transform.position;
            clone.transform.SetAsLastSibling();

            // Set the parent of the clone to the original parent
            cloneParent = transform.parent;
            clone.transform.SetParent(cloneParent);

            // Disable raycast on the original image
            image.raycastTarget = false;
        }
    }

    /**
    * OnDrag method to handle dragging the drag
    * Moves the clone according to the pointer
    * @return void
    */
    public void OnDrag(PointerEventData eventData)
    {
        if(skillTreeController.unlockedSpells.Contains(spellID))
        {
            Debug.Log("Dragging");
            clone.transform.position = Input.mousePosition;
        }
    }

    /**
    * OnEndDrag method to handle dropping the gameObject
    * If gameObject is not dropped in skillSlot, it is destroyed
    * @return void
    */
    public void OnEndDrag(PointerEventData eventData)
    {
        if(skillTreeController.unlockedSpells.Contains(spellID))
        {
            Debug.Log("End Drag");

            // Enable raycast on the original image
            image.raycastTarget = true;

            // Set the parent of the clone to the original parent
            clone.transform.SetParent(cloneParent);
            clone.transform.SetAsLastSibling();

            // Enable raycast on the clone image
            clone.GetComponent<Image>().raycastTarget = true;

            // Check if the clone is in the skill slot
            if (clone.transform.parent.GetComponent<SkillSlot>() == null)
            {
                // Destroy the clone if it's not in the skill slot
                Debug.Log("Clone not in skill slot, destroying clone");
                Destroy(clone);
            }
        }
    }
}