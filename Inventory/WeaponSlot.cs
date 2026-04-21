using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* WeaponSlot class for handling weapon functionalities
*/
public class WeaponSlot : MonoBehaviour
{
    private WeaponInventory weaponInventory;
    public int i;

    void Start()
    {
        weaponInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponInventory>();
    }

    /**
    * Update method to check whether the game object has any child objects
    * @return void
    */
    void Update()
    {
        if (transform.childCount <= 0)
        {
            weaponInventory.isFull[i] = false;
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
