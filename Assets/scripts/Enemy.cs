using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {

	Punchattack punch;
	ThrowKnives knives;
	FollowTarget followTarget;

	public float attackRate = .5f;
	public float rangeAttackRate = 3.0f;
	float attackTimeout = .0f;
	float rangeAttackTimeout = .0f;

	public float rangeAttackRange = 12.0f;

	// Use this for initialization
	void Start () {
		punch = GetComponentInChildren<Punchattack>();
		knives = GetComponentInChildren<ThrowKnives>();
		followTarget = GetComponent<FollowTarget>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<HealthEnemy>().health <= .0f)
		{
			followTarget.enabled = false;
			GetComponent<Collider2D>().enabled = false;
			return;
		}

		if (followTarget.GetDistance() < 2.0f && attackTimeout < .0f) {
			punch.PerformAttack();
			attackTimeout = attackRate;
		}

		if (knives && followTarget.GetDistance() < rangeAttackRange && rangeAttackTimeout < .0f)
		{
			knives.PerformAttack();
			rangeAttackTimeout = rangeAttackRate;
		}

		rangeAttackTimeout-= Time.deltaTime;
		attackTimeout -= Time.deltaTime;
	}
}
