using UnityEngine;
using System.Collections;

public class TrackingSpreadShooterAI : MonoBehaviour
{

    public float xSpeed;
    public float ySpeed;
    public float health;
    public float reloadSpeed;
    public GameObject bullet;

    private float objectWidth;
    private float objectHeight;
    private float bulletHeight;
    private float shotCooldown = 0;


    void Start()
    {
        objectWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        bulletHeight = bullet.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        other.SendMessage("ApplyDamage", 1);
    }

    void ApplyDamage(int damage)
    {
        health -= damage;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }


        float time = Time.deltaTime;
        float screenHeight = Camera.main.orthographicSize;
        float screenWidth = screenHeight * Screen.width / Screen.height;

        Vector3 pos = transform.position;

        pos.y += time * ySpeed;
        pos.x += time * xSpeed;

        //Remove the object if it is out of bounds
        if (pos.y > screenHeight + objectHeight ||
            pos.y < -screenHeight - 2 * objectHeight)
        {
            Destroy(gameObject);
        }


        if (pos.x >= screenWidth - objectWidth)
        {
            xSpeed = -xSpeed;
            pos.x = 2 * (screenWidth - objectWidth) - pos.x;
        }
        else if (pos.x <= -screenWidth + objectWidth)
        {
            pos.x = 2 * (-screenWidth + objectWidth) - pos.x;
            xSpeed = -xSpeed;
        }

        transform.position = pos;

        shotCooldown -= time;
        if (shotCooldown <= 0)
        {
            Vector3 bulletPos = transform.position;
            bulletPos.y -= objectHeight;
            bulletPos.y += bulletHeight;
            GameObject shot = Instantiate(bullet, bulletPos, transform.rotation) as GameObject;
            shot.SendMessage("track","left");
            shot = Instantiate(bullet, bulletPos, transform.rotation) as GameObject;
            shot.SendMessage("track","right");
            shot = Instantiate(bullet, bulletPos, transform.rotation) as GameObject;
            shot.SendMessage("track", "middle");
            shotCooldown += reloadSpeed;
        }

    }
}
