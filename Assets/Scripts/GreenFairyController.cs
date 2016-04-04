using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GreenFairyController : MonoBehaviour {

    float speed = 5f;
    float moveX = 0f;
    float moveY = 0f;
    public static int direction = 0;
    int previousDirection; //up=0, down=1, left=2, right=3
    int wait = 0;
    public GameObject bullet;
    public GameObject web;
    GameObject clone;
    public Text redScore;
    public Text greenScore;
    bool up, down, left, right;

    // Use this for initialization
    void Start () {
	    
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        up = Input.GetKey(KeyCode.UpArrow);
        down = Input.GetKey(KeyCode.DownArrow);
        left = Input.GetKey(KeyCode.LeftArrow);
        right = Input.GetKey(KeyCode.RightArrow);

        if (wait == 251)
        {
            speed = 5f;
            Destroy(clone);
            wait = 0;
        }
        else if (wait < 251 && wait > 0)
        {
            wait += 1;
        }

        if (up && !down && !left && !right)
        {
            previousDirection = direction;
            direction = 0;
            moveY = Input.GetAxis("Vertical");
            moveX = 0f;
            flipFairy(direction, previousDirection);
        }
        else if (down && !up && !left && !right)
        {
            previousDirection = direction;
            direction = 1;
            moveY = Input.GetAxis("Vertical");
            moveX = 0f;
            flipFairy(direction, previousDirection);
        }
        else if (left && !up && !down && !right)
        {
            previousDirection = direction;
            direction = 2;
            moveX = Input.GetAxis("Horizontal");
            moveY = 0f;
            flipFairy(direction, previousDirection);
        }
        else if (right && !left && !up && !down)
        {
            previousDirection = direction;
            direction = 3;
            moveX = Input.GetAxis("Horizontal");
            moveY = 0f;
            flipFairy(direction, previousDirection);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, moveY * speed);
        

        if (Input.GetKeyDown(KeyCode.Slash))
        {
            if (wait == 0) {
                Instantiate(bullet, transform.position, transform.rotation);
            }

        }

        if (RedSpiderSpawner.killedSpiders == RedSpiderSpawner.totalSpiders || GreenSpiderSpawner.killedSpiders == GreenSpiderSpawner.totalSpiders)
        {
            SceneManager.LoadScene(2);
            direction = 0;
        }
        else {
            if (redScore != null)
            {
                redScore.text = "Red Spiders: " + RedSpiderSpawner.killedSpiders + "/" + RedSpiderSpawner.totalSpiders;
            }
            if (greenScore != null)
            {
                greenScore.text = "Green Spiders: " + GreenSpiderSpawner.killedSpiders + "/" + GreenSpiderSpawner.totalSpiders;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Background" && collision.gameObject.tag != "Red Fairy") {
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
        if (collision.gameObject.tag == "Background")
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
        if (collision.gameObject.tag == "Red Spider" && wait == 0)
        {
            this.speed = 0;
            wait = 1;
            if (clone != null)
            {
                Destroy(clone);
            }
            clone = Instantiate(web, transform.position, transform.rotation) as GameObject;
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

    void OnCollisionExit2D()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
    }


    void flipFairy(int current, int previous)
    {
        if (current != previous)
        {
            if ((current == 0 && previous == 1) || (current == 1 && previous == 0) || (current == 2 && previous == 3) || (current == 3 && previous == 2))
            {
                GetComponent<Transform>().Rotate(0, 0, 180);
            }
            else if ((current == 0 && previous == 2) || (current == 1 && previous == 3) || (current == 2 && previous == 1) || (current == 3 && previous == 0))
            {
                GetComponent<Transform>().Rotate(0, 0, 270);
            }
            else if ((current == 0 && previous == 3) || (current == 1 && previous == 2) || (current == 2 && previous == 0) || (current == 3 && previous == 1))
            {
                GetComponent<Transform>().Rotate(0, 0, 90);
            }
        }
    }
}
