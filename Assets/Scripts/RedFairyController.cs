using UnityEngine;
using System.Collections;

public class RedFairyController : MonoBehaviour {

    float speed = 5f;
    float moveX = 0f;
    float moveY = 0f;
    public static int direction = 0;
    int previousDirection; // up=0, down=1, left=2, right=3
    public GameObject bullet;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        bool up = Input.GetKey("w");
        bool down = Input.GetKey("s");
        bool left = Input.GetKey("a");
        bool right = Input.GetKey("d");
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


        if (Input.GetKeyDown("5"))
        {
            //GetComponent<Animator>().SetBool("shoot", true);

            Instantiate(bullet, transform.position, transform.rotation);
        }
        //GetComponent<Animator>().SetBool("shoot", false);

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
