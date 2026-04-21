using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* ItemSlot class for handling ItemSlot functionalities
*/
public class ItemSlot : MonoBehaviour
{
    private Inventory inventory;
    public int i;


    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    /**
    * Update method to check whether the game object has any child objects
    * @return void
    */
    void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }

    /**
    * DropItem method to drop all child objects of gameObject
    * @return void
    */
    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
