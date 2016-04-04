using UnityEngine;
using System.Collections;

public class GreenSpiderController : MonoBehaviour {

    int direction = 1, previousDirection; // up=0, down=1, left=2, right=3
    int speed = 1;
    bool collisionOccured = false, destinationReached = false;
    bool xReached = false, yReached = false;
    Vector2 destination;
    Quaternion currentRotation;

    // Use this for initialization
    void Start()
    {
        destination = new Vector2(Random.Range(-7.74f, 6.25f), Random.Range(1.85f, 7.31f));
        GetComponent<Transform>().position = new Vector3(Random.Range(-7.74f, 6.25f), Random.Range(1.85f, 7.31f), 0);
        GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
        currentRotation = GetComponent<Transform>().rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!destinationReached && !collisionOccured)
        {
            moveDirection();
        }
        if (collisionOccured)
        {
            destinationReached = true;
            collisionOccured = false;
            if (currentRotation != null)
            {
                GetComponent<Transform>().rotation = currentRotation;
            }
        }
        if (destinationReached)
        {
            destination = new Vector2(Random.Range(-7.74f, 6.25f), Random.Range(1.85f, 7.31f));
            destinationReached = false;
            xReached = false;
            yReached = false;
            if (direction == 0)
            {
                destination.y = 1.78f;
            }
            else if (direction == 1)
            {
                destination.y = 7.37f;
            }
            else if (direction == 2)
            {
                destination.x = 6.79f;
            }
            else if (direction == 3)
            {
                destination.x = -7.65f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        collisionOccured = true;
        destinationReached = true;
        currentRotation = GetComponent<Transform>().rotation;
    }

    void moveDirection()
    {
        if (destination.y - 1 < GetComponent<Transform>().position.y && destination.y + 1 > GetComponent<Transform>().position.y)
        {
            yReached = true;
        }
        if (destination.x - 1 < GetComponent<Transform>().position.x && destination.x + 1 > GetComponent<Transform>().position.x)
        {
            xReached = true;
        }
        if (!xReached || !yReached)
        {
            if (destination.y > GetComponent<Transform>().position.y && !yReached)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
                previousDirection = direction;
                direction = 0;
                flipSpider(direction, previousDirection);
            }
            else if (destination.y < GetComponent<Transform>().position.y && !yReached)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed * -1);
                previousDirection = direction;
                direction = 1;
                flipSpider(direction, previousDirection);
            }
            else if (destination.x < GetComponent<Transform>().position.x && !xReached)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -1, 0);
                previousDirection = direction;
                direction = 2;
                flipSpider(direction, previousDirection);
            }
            else if (destination.x > GetComponent<Transform>().position.x && !xReached)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
                previousDirection = direction;
                direction = 3;
                flipSpider(direction, previousDirection);
            }
        }
        else if (yReached && xReached)
        {
            destinationReached = true;
        }
        
    }

    void flipSpider(int current, int previous)
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
