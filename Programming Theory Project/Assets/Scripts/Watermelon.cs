using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : Fruit
{
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        startPosition = transform.position;

        fruitName = "Watermelon";
        fruitFlavor = "Watery";
        fruitPoints = 5;

        bobSpeed = 2.5f;
        bobHeight = 4.5f;
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
