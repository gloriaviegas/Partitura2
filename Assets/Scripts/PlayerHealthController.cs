using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerhealthController : MonoBehaviour
{
    public static PlayerhealthController instance;

    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;

    [SerializeField] private float invincibilitylenght;
    private float invincibityCounter;

    private SpriteRenderer sr;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color fadeColor;
    

    private PlayerController player;



    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        player = GetComponent<PlayerController>();

        UIController.instance.UpdateHealthDisplay(currentHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibityCounter > 0)
        {

            invincibityCounter -= Time.deltaTime;

            if (invincibityCounter <= 0)
            {
                sr.color = normalColor;
                //anim.SetBool("istakedamage", false);
            }

        }
#if UNITY_EDITOR // Diretiva de pré-processador

        if (Input.GetKeyDown(KeyCode.H))
        {
            AddHealth(1);

        }
#endif   

    }

    public void DamagePlayer()
    {
        if (invincibityCounter <= 0)
        {
            currentHealth--;
            //anim.SetBool("istakedamage", true);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                gameObject.SetActive(false);

            }
            else
            {
                invincibityCounter = invincibilitylenght;
                sr.color = fadeColor;
                player.Knockback();

            }

            UIController.instance.UpdateHealthDisplay(currentHealth, maxHealth);
        }
    }
    public void AddHealth(int amountToAdd)
    {


        currentHealth += amountToAdd;

        if (currentHealth >= maxHealth)

        {
            currentHealth = maxHealth;

        }

        UIController.instance.UpdateHealthDisplay(currentHealth,maxHealth);

    
    }
}
