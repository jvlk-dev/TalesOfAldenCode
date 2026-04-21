using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* WeaponInventory class for handling the weapon visibility
*/
public class WeaponInventory : MonoBehaviour
{
    public int[] weaponIDS;
    public bool[] isFull;
    public GameObject[] slots;

    [SerializeField] private GameObject slot1;
    [SerializeField] private GameObject slot2;

    [SerializeField] private GameObject damascusSwordHand;
    [SerializeField] private GameObject rubberSwordHand;

    [SerializeField] private GameObject damascusSwordBack;
    [SerializeField] private GameObject rubberSwordBack;

    /**
    * Update method for updating the active gameObject in inventory slot
    * @return void
    */
    void Update()
    {
        if (isFull[0])
        {
            if (weaponIDS[0] == 1)
            {
                damascusSwordHand.SetActive(true);
                rubberSwordHand.SetActive(false);
            }
            if (weaponIDS[0] == 2)
            {
                damascusSwordHand.SetActive(false);
                rubberSwordHand.SetActive(true);
            }
        }
        else if (!isFull[0])
        {
            damascusSwordHand.SetActive(false);
            rubberSwordHand.SetActive(false);
        }

        if (isFull[1])
        {
            if (weaponIDS[1] == 1)
            {
                damascusSwordBack.SetActive(true);
                rubberSwordBack.SetActive(false);
            }
            if (weaponIDS[1] == 2)
            {
                damascusSwordBack.SetActive(false);
                rubberSwordBack.SetActive(true);
            }
        }
        else if (!isFull[1])
        {
            damascusSwordBack.SetActive(false);
            rubberSwordBack.SetActive(false);
        }
    }

    /**
    * SwapInventorySlots method for updating the active gameObject in inventory slot by swapping between slots
    * @return void
    */
    public void SwapInventorySlots()
    {
        bool tempFullSlot1 = isFull[0];
        int tempWeaponID1 = weaponIDS[0];
        GameObject tempItemButton1 = slots[0].transform.GetChild(0).gameObject;

        bool tempFullSlot2 = isFull[1];
        int tempWeaponID2 = weaponIDS[1];
        GameObject tempItemButton2 = slots[1].transform.GetChild(0).gameObject;

        // Store references to previous GameObjects and their active state
        GameObject prevItemButton1 = slots[0].transform.GetChild(0).gameObject;
        bool prevActive1 = prevItemButton1.activeSelf;

        GameObject prevItemButton2 = slots[1].transform.GetChild(0).gameObject;
        bool prevActive2 = prevItemButton2.activeSelf;

        isFull[0] = tempFullSlot2;
        weaponIDS[0] = tempWeaponID2;

        // Instantiate new GameObjects and set their active state based on previous ones
        GameObject newItemButton1 = Instantiate(tempItemButton2, slots[0].transform);
        Image newImage1 = newItemButton1.GetComponent<Image>();
        newImage1.enabled = prevActive2;

        isFull[1] = tempFullSlot1;
        weaponIDS[1] = tempWeaponID1;

        GameObject newItemButton2 = Instantiate(tempItemButton1, slots[1].transform);
        Image newImage2 = newItemButton2.GetComponent<Image>();
        newImage2.enabled = prevActive1;

        // Destroy previous GameObjects, but not their Image components
        if (prevItemButton1 != newItemButton1)
        {
            Destroy(prevItemButton1);
        }
        if (prevItemButton2 != newItemButton2)
        {
            Destroy(prevItemButton2);
        }
    }
}
