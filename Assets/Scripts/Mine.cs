using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

	public float speed;
	GameObject player;
	public float health;

	private bool detonate = false;

	private float explosionTimer = 0;
	private float blinkTimer = 0;



	private Vector3 targetPos;
	void Start()
	{
		player = GameObject.Find("Player");
	}

	void ApplyDamage(int damage)
	{
		health -= damage;
	}

	// Update is called once per frame
	void Update () {

		if (detonate == false)
		{
			if (health <= 0)
			{
				detonate = true;
			}

			Vector3 moveTowardsVector = transform.position - player.transform.position;
			float distance = moveTowardsVector.x * moveTowardsVector.x + moveTowardsVector.y * moveTowardsVector.y;
			if (distance < 0.25f)
			{
				detonate = true;
			}

			float time = Time.deltaTime;

			float step = speed * time;
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

		} else
		{
			explosionTimer += Time.deltaTime;
			if (explosionTimer > 0.75f)
			{
				GetComponent<Renderer>().enabled = false;
				Vector3 moveTowardsVector = transform.position - player.transform.position;
				float distance = moveTowardsVector.x * moveTowardsVector.x + moveTowardsVector.y * moveTowardsVector.y;
				if (distance <= 0.3f)
				{
					player.SendMessage("ApplyDamage",6);
				}
				Destroy(gameObject);
			}
			else if (explosionTimer > 0.5f)
			{
				GetComponent<Renderer>().enabled = false;
				transform.GetChild(0).transform.localScale += new Vector3(40, 40, 0) * Time.deltaTime;
			}
			else
			{
				blinkTimer += Time.deltaTime;
				if (blinkTimer > 0.07f)
				{
					GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
					blinkTimer -= 0.07f;

				}
			}
		}
	}
}
