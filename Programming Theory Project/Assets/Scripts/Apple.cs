using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Fruit
{
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        startPosition = transform.position;

        fruitName = "Apple";
        fruitFlavor = "Sweet";
        fruitPoints = 3;

        bobSpeed = 4f;
        bobHeight = 3f;
    }

    private void Update()
    {
        BobUpAndDown(startPosition, bobSpeed, bobHeight);
    }
   
    private void OnTriggerEnter(Collider other)
    {
        CollectFruit(fruitName, fruitFlavor, fruitPoints);
        gameObject.SetActive(false);
        Debug.Log("Collision");
    }
}
