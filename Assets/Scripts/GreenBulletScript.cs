﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GreenBulletScript : MonoBehaviour {

    public int speed = 0;
    public int direction;
    public GameObject spider;

    // Use this for initialization
    //initialises direction and velocity of bullet
    void Start () {
        direction = GreenFairyController.direction;
        if (direction == 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }
        else if (direction == 1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed * -1);
        }
        else if (direction == 2)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -1, 0);
        }
        else if (direction == 3)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
    }

    // checks for collisions with red spider, spawns two more green spiders and updates score
    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "Red Spider")
        {
            Destroy(gameObject);
            Destroy(otherObject.gameObject);
            Instantiate(spider);
            Instantiate(spider);
            RedSpiderSpawner.killedSpiders += 1;
            GreenSpiderSpawner.totalSpiders += 2;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
