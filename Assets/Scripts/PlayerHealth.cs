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

    [SerializeField] private AudioClip clip;

    public static PlayerHealth Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        Instance = this;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);

    }

    private void ResetHealth()
    {
        currentHealth = CurrentSceneManager.Instance.GetStartSceneHealth();
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            AudioManager.Instance.PlayClipAt(clip, transform.position);

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
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        body.isKinematic = true;
        body.velocity = Vector3.zero;

        //GameOverMenu
        GameOverManager.Instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        //débloquer les mouvement
        gameObject.GetComponent<MovePlayer>().enabled = true;
        //quitter l'animation de mort
        gameObject.GetComponent<Animator>().SetTrigger("Respawn");
        //retrouver les interactions
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        
        ResetHealth();

    }

    public int GetHealth()
    {
        return currentHealth;
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
