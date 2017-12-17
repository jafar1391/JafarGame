using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour {

    public Image healthBar;
    public float health = 1;
    public float maxhealth = 1.0f;


    private void Start()
    {
        health = maxhealth;
    }


    void Update()
    {
        if (health <= 0)
        {
            GetComponent<Animator>().SetBool("isDying", true);
        }

        if (healthBar)
            healthBar.fillAmount = Mathf.Lerp(0.3f, 0.95f, health / maxhealth);

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Taking Damage: " + damage);
    }
}
