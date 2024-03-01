using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    public GameObject food;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
        int y = (int)Random.Range(borderTop.position.y, borderBottom.position.y);
        Instantiate(food, new Vector2(x, y), Quaternion.identity);
    }
    public void StartSpawnFood()
    {
        InvokeRepeating("Spawn", 3, 4);
    }
}
