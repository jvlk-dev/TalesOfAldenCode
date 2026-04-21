using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* PlayerHealthManager class for handling player health
*/
public class PlayerHealthManager : MonoBehaviour, IDataPersistence
{
    [Header("Objects")]
    [SerializeField] private GameObject DeathScreen;

    [Header("Controllers")]
    [SerializeField] private Animator animator;

    [Header("Stats")]
    public float MaxHealth = 100;
    public bool Alive = true;
    public bool playerCanTakeDamage = true;

    [SerializeField] private float currentHealth;
    /**
    * CurrentHealth property
    * @return currentHealth
    * @param value
    */
    public float CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = value;
            if (currentHealth <= 0)
            {
                animator.SetBool("died", true);
                Alive = false;
                StartCoroutine(Death());
            }
        }
    }

    /**
    * Death method to handle player death
    * @return void
    */
    IEnumerator Death()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 0f;
        currentHealth = 0;
        DeathScreen.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


    // Start is called before the first frame update
    void Start()
    { 
        currentHealth = MaxHealth;
    }

    /**
    * LoadData method from IDataPersistence
    * @param data
    * @return void
    */
    public void LoadData(GameData data)
    {
        this.currentHealth = data.playerHealth;
    }

    /**
    * SaveData method from IDataPersistence
    * @param data
    * @return void
    */
    public void SaveData(ref GameData data)
    {
        data.playerHealth = this.currentHealth;
    }

    /**
    * PlayerTakesDamage method to handle player damage
    * @param damage from weapon collider
    * @return void
    */
    public void PlayerTakesDamage(float damage)
    {
        if (CurrentHealth - damage > MaxHealth)
        {
            if (playerCanTakeDamage)
            {
                animator.SetTrigger("gotHit");
                CurrentHealth = MaxHealth;
                CurrentHealth -= damage;
                playerCanTakeDamage = false;
                Invoke(nameof(ResetCanTakeDamage), 2);
            }
        }
        else
        {
            if (playerCanTakeDamage)
            {
                animator.SetTrigger("gotHit");
                CurrentHealth -= damage;
                playerCanTakeDamage = false;
                Invoke(nameof(ResetCanTakeDamage), 2);
            }
        }
    }

    /**
    * PlayerHeals method to handle player healing
    * @param amount of health added by heal source
    * @return void
    */
    public void PlayerHeals(float amount)
    {
        if (CurrentHealth + amount > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        else
        {
            CurrentHealth += amount;
        }
    }

    /**
    * ResetCanTakeDamage method to reset playerCanTakeDamage bool
    * @return void
    */
    private void ResetCanTakeDamage()
    {
        playerCanTakeDamage = true;
    }
}
