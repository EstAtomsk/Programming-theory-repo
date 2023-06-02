using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avocado : Fruit
{
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        startPosition = transform.position;

        fruitName = "Avocado";
        fruitFlavor = "Unknown";
        fruitPoints = 7;

        bobSpeed = 3f;
        bobHeight = 5.5f;
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
