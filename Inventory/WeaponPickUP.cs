using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* WeaponPickUP class for handling weapon pick up
*/
public class WeaponPickUP : MonoBehaviour
{
    private WeaponInventory weaponInventory;

    [SerializeField] private GameObject itemButton;

    [SerializeField] private int weaponID;
    // Start is called before the first frame update
    void Start()
    {
        weaponInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponInventory>();
    }

    /**
    * OnCollisionEnter method for instantiating itemButton UI for the specific item
    * Destroys the gameObject
    * @return void
    */
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            for (int i = 0; i < weaponInventory.slots.Length; i++)
            {
                if (weaponInventory.isFull[i] == false)
                {
                    // add item
                    weaponInventory.isFull[i] = true;
                    weaponInventory.weaponIDS[i] = weaponID;
                    Instantiate(itemButton, weaponInventory.slots[i].transform);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
