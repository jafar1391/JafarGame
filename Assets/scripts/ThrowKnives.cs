using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowKnives : MonoBehaviour {

	public GameObject projectilePrefab;
	GameObject projectile;
	public LayerMask applyDamageMask;
	public Sprite sprite;
	public float strength = 0.2f;
	public float speed = 0.5f;
	
	// Update is called once per frame
	void Update () {
		if (projectile) {
			Collider2D collider = Physics2D.OverlapBox(projectile.transform.position,
				new Vector2(1.0f, 1.0f),
				.0f, applyDamageMask);

			if (collider) {
				var health = collider.GetComponent<Health>() ?? collider.GetComponentInParent<Health>();

				if (health)
				{
					health.TakeDamage(strength);
				}
				Destroy(projectile);
			}

			projectile.transform.Translate(-transform.right * speed);
		}
	}

	public void PerformAttack()
	{
		Debug.Log("Knife thrown");

		if (projectile) Destroy(projectile);

		projectile = Instantiate(projectilePrefab);

		// projectile = new GameObject();
		// projectile.AddComponent<BoxCollider2D>();
		// projectile.AddComponent<SpriteRenderer>().sprite = sprite;

		projectile.transform.position = transform.position;
		projectile.transform.localScale = Vector3.one * 3.0f;
	}

	void OnDisable()
	{
		if(projectile)
			Destroy(projectile);
	}
}
