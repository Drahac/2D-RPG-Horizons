using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 10;
    private int currentHealth;

    private bool isInvincible = false;
    private float flash_time = 0.15f;
    private float invincibilityDelay = 2f;

    [SerializeField] private HealthBar healthBar;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            //vérifie rsi le joueur est vivant
            if (currentHealth <= 0)
            {
                Die();
                return;
            }
            else
            {

                isInvincible = true;
                StartCoroutine(InvincibilityFlash());
                StartCoroutine(HandleInvincibilityDelay());
            }
        }
    }

    public void HealPlayer(int healing)
    {
        currentHealth += healing;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
    }


    private void Die()
    {
        //bloquer les mouvement
        gameObject.GetComponent<MovePlayer>().enabled = false;
        //animation de mort
        gameObject.GetComponent<Animator>().SetTrigger("Death");
        //empecher les interactions
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

    }


    private IEnumerator InvincibilityFlash() {
        while (isInvincible)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(flash_time);
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(flash_time);
        }
    }

    private IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityDelay);
        isInvincible = false;
    }
}
