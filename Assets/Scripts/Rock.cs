using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

	public float ySpeed;
	public int health;

	private float objectWidth;
	private float objectHeight;
	private bool hasDealtDamage = false;
	private bool kill = false;

	// Use this for initialization
	void Start () {
		objectWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
		objectHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (kill || health <= 0)
		{
			Destroy(gameObject);
		}

		float time = Time.deltaTime;
		Vector3 pos = transform.position;

		float screenHeight = Camera.main.orthographicSize;
		float screenWidth = screenHeight * Screen.width / Screen.height;

		pos.y += time * ySpeed;

		//Remove the object if it is out of bounds
		if (pos.y > screenHeight + objectHeight ||
			pos.y < -screenHeight - objectHeight ||
			pos.x > screenWidth + objectWidth ||
			pos.x < -screenWidth - objectWidth)
		{
			Destroy(gameObject);
		}

		transform.position = pos;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == 11)
		{

			if (!hasDealtDamage)
			{
				other.SendMessage("ApplyDamage", 5);

			}
			hasDealtDamage = true;
			kill = true;
		}
	}

	void ApplyDamage(int damage)
	{
		health -= 1;
	}
}
