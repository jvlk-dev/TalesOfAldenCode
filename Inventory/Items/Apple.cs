using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Apple class for handling the usage of gameObject
*/
public class Apple : MonoBehaviour
{
    private PlayerHealthManager playerHealthManager;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealthManager = player.GetComponent<PlayerHealthManager>();
    }

    // Update is called once per frame
    public void Use()
    {
        playerHealthManager.PlayerHeals(20f);
        Destroy(gameObject);
    }
}
