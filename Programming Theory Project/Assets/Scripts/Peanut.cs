using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peanut : Fruit
{
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        startPosition = transform.position;

        fruitName = "Peanut";
        fruitFlavor = "NOT A FRUIT";
        fruitPoints = 1;

        bobSpeed = 1f;
        bobHeight = 1.5f;
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
