using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCarrier : MonoBehaviour
{


	public float timer = -5;
	public float cooldown;
	public int phase = 1;

	public GameObject first;
	public GameObject second;
	public GameObject last;


	// Update is called once per frame
	void Update()
	{

		timer += Time.deltaTime;
		if (timer > cooldown)
		{
			timer -= cooldown;
			if (phase == 1)
			{
				Instantiate(first, transform.position, transform.rotation);
			}else if (phase == 2)
			{
				Instantiate(second, transform.position, transform.rotation);
			}
			else if(phase == 3)
			{
				Instantiate(last, transform.position, transform.rotation);
			} 
		}
	}
}
