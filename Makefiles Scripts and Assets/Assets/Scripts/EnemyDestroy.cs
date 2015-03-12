using UnityEngine;
using System.Collections;

public class EnemyDestroy : MonoBehaviour
{
	public int health;
	private float invuln = 0f;
	public float invulnPeriod;

	SpriteRenderer spriteRender;

	void Start()
	{
		if (spriteRender == null)
		{
			spriteRender = transform.GetComponentInChildren<SpriteRenderer>();
			if(spriteRender == null)
			{Debug.LogError ("Object " + gameObject.name + " has no sprite renderer");}
		}
	}

	void OnTriggerEnter2D() //If the collider's NOT a trigger, use OnCollisionEnter2D - depends on what you want to do
	{
		if (invuln <= 0)
		{
			health--;
			invuln = invulnPeriod;
		}
	}

	void Update()
	{
		invuln -= Time.deltaTime;
		if (invuln > 0) {
			gameObject.collider2D.enabled = false;
			if (spriteRender != null)
			{spriteRender.enabled = !spriteRender.enabled;}
		} else {
			gameObject.collider2D.enabled = true;
			invuln = 0;
			if (spriteRender != null)
			{spriteRender.enabled = true;}
		}
		if (health == 0) {
			Die ();
		}
	}

	void Die()
	{
		Destroy (gameObject);
		if (gameObject.name == "EnemyShip")
		{
			ScoreMarker.score += 100;
		}
	}
}
