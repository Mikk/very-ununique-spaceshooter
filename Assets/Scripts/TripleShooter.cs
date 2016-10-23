using UnityEngine;
using System.Collections;

public class TripleShooter : MonoBehaviour
{


	private float shotCooldown = 0;
	private float bulletHeight;
	public float reloadSpeed;
	public GameObject bullet;
	private float objectHeight;

	// Use this for initialization
	void Start()
	{

		objectHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
		bulletHeight = bullet.GetComponent<SpriteRenderer>().bounds.size.y / 2;

	}

	// Update is called once per frame
	void Update()
	{
		float time = Time.deltaTime;
		shotCooldown -= time;
		if (shotCooldown <= 0)
		{
			Vector3 bulletPos = transform.position;
			bulletPos.y -= objectHeight;
			bulletPos.y += bulletHeight;
			GameObject shot = Instantiate(bullet, bulletPos, transform.rotation) as GameObject;
			shot.SendMessage("track", "left");
			shot = Instantiate(bullet, bulletPos, transform.rotation) as GameObject;
			shot.SendMessage("track", "right");
			shot = Instantiate(bullet, bulletPos, transform.rotation) as GameObject;
			shot.SendMessage("track", "middle");
			shotCooldown += reloadSpeed;
		}
	}
}
