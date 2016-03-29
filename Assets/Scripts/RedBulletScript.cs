using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RedBulletScript : MonoBehaviour {

    public int speed = 0;
    public int direction;
    public GameObject spider;


    // Use this for initialization
    void Start () {
        direction = RedFairyController.direction;
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
	
    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "Green Spider")
        {
            Destroy(gameObject);
            Destroy(otherObject.gameObject);
            Instantiate(spider);
            Instantiate(spider);
            GreenSpiderSpawner.killedSpiders += 1;
            RedSpiderSpawner.totalSpiders += 2;
        }

        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

	// Update is called once per frame
	void FixedUpdate () {
        
    }


}
