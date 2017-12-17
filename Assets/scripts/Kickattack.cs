using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kickattack : MonoBehaviour
{
    Animator Animator;
    AudioSource sound;

    public float strength = 0.5f;

    bool performAttack = false;

    private void Start()
    {
        Animator = GetComponentInParent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<HealthEnemy>() && collision.gameObject.layer != gameObject.layer && performAttack)
        {       
            collision.GetComponent<HealthEnemy>().TakeDamage(strength);          
        }
        performAttack = false;
    }

    public void PerformAttack()
    {
        Animator.SetBool("isKicking", true);
        performAttack = true;
        sound.Play();
        Invoke("CancelKicking", Time.deltaTime);
    }

    void Update()
    {
        Animator.SetBool("isKicking", false);
    }

    void CancelKicking()
    {
        Animator.SetBool("isPunching", false);
    }
}
