using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* ItemPickUP class for handling itemPickup
*/
public class ItemPickUP : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField] private GameObject itemButton;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
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
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    // add item
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
