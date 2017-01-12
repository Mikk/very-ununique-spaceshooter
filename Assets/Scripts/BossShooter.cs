using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooter : MonoBehaviour {


	public float timer = -5;
	public float cooldown;
	public int phase = 1;

	public GameObject bullet;
	public GameObject missile;
	public GameObject bomb;

	public bool missileActive = false;
	public bool bombActive = false;

	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		if (timer > cooldown)
		{
			timer -= cooldown;
			phase++;

			if (phase == 4)
			{
				phase = 1;
			}

			if (phase == 3 && missileActive)
			{
				Instantiate(missile, transform.position, missile.transform.rotation);
			} else if (phase == 2 && bombActive) {
				Instantiate(bomb, transform.position, transform.rotation);
			} else
			{
				GameObject ob = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
				ob.SendMessage("track","middle"); 
			}
		}
	}
}
