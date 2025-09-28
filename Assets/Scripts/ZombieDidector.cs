using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ZombieDidector : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    float maxHealth = 1;
    float currentHealth;

    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.fillAmount = 1;
    }

    public void Death()
    {
        Debug.Log("Death");
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            currentHealth -= 0.10f;
            healthBar.fillAmount = currentHealth;

            if (currentHealth < 0)
            {
                Death();
            }
        }
    }
}
