using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punchattack : MonoBehaviour {

    Animator Animator;
    AudioSource sound;

    public float strength = .33f;

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
        Animator.SetBool("isPunching", true);
        performAttack = true;
        if (sound) sound.Play();
        Invoke("CancelPunching", Time.deltaTime);
    }

    void CancelPunching()
    {
        Animator.SetBool("isPunching", false);
    }
}
