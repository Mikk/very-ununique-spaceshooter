using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float speed;
    public int health;
    public float reloadSpeed;
    public GameObject bullet;

    public float invLength;

    private float playerWidth;
    private float playerHeight;
    private float bulletHeight;
    private float shotCooldown = 0;
    private float invCooldown = 0;

    void Start()
    {
        playerWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        playerHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        bulletHeight = bullet.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (invCooldown == 0)
        {
            //other.SendMessage("ApplyDamage", 1);
        }
    }

    void ApplyDamage(int damage)
    {
        if (invCooldown == 0)
        {
            health -= damage;
            invCooldown = invLength;
        }
    }

    void Update()
    {
        float time = Time.deltaTime;
        Vector3 pos = transform.position;

        float screenHeight = Camera.main.orthographicSize;
        float screenWidth = screenHeight * Screen.width / Screen.height;

        //Health check
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        //Movement
        pos.y += Input.GetAxis("Vertical") * time * speed;
        pos.x += Input.GetAxis("Horizontal") * time * speed;

        //Keep object in the bounds
        if (pos.y > screenHeight - playerHeight)
        {
            pos.y = screenHeight - playerHeight;
        }
        else if (pos.y < -screenHeight + playerHeight)
        {
            pos.y = -screenHeight + playerHeight;
        }
        if (pos.x > screenWidth - playerWidth)
        {
            pos.x = screenWidth - playerWidth;
        }
        else if (pos.x < -screenWidth + playerWidth)
        {
            pos.x = -screenWidth + playerWidth;
        }

        transform.position = pos;

        //Shooting
        shotCooldown -= time;
        if (shotCooldown <= 0)
        {
            shotCooldown = 0;
            if (Input.GetAxis("Fire") != 0)
            {
                Vector3 bulletPos = transform.position;
                bulletPos.y += playerHeight;
                bulletPos.y -= bulletHeight;
                Instantiate(bullet, bulletPos, transform.rotation);
                shotCooldown = reloadSpeed;
            }
        }

        //Invurnability time reduction
        invCooldown -= time;
        if (invCooldown < 0)
        {
            invCooldown = 0;
        }
    }
}
