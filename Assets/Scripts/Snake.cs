using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2 moveDirection = Vector2.right;

    bool eat = false;

    public GameObject tailPrefab;
    List<Transform> tail = new List<Transform>();
    void Start()
    {
        InvokeRepeating("Move", 0.3f, 0.3f);
    }

    void Update()
    {
        if (moveDirection.x == 0)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                moveDirection = Vector2.right;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                moveDirection = Vector2.left;
        }
        if (moveDirection.y == 0)
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                moveDirection = Vector2.down;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                moveDirection = Vector2.up;
        }
    }

    void Move()
    {
        Vector2 vector = transform.position;
        transform.Translate(moveDirection);
        if (eat)
        {
            GameObject gameObject = (GameObject)Instantiate(tailPrefab, vector, Quaternion.identity);
            tail.Insert(0, gameObject.transform);
            eat = false;
        }
        else if (tail.Count > 0)
        {
            tail[tail.Count - 1].position = vector;
            tail.Insert(0, tail[tail.Count - 1]);
            tail.RemoveAt(tail.Count - 1);        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.name.StartsWith("Food"))
        {
            eat = true;
            Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log("Morreu");
        }
    }
}
