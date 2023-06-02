using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fruit : MonoBehaviour
{
    protected GameManager gameManager;

    protected string fruitName;
    protected string fruitFlavor;
    protected int fruitPoints;

    protected float bobSpeed;
    protected float bobHeight;

    protected Vector3 startPosition;

    public virtual void BobUpAndDown(Vector3 pos, float bobSpeed, float bobHeight)
    {
        float newY = (Mathf.Sin(Time.time * bobSpeed)) + bobHeight;

        transform.position = new Vector3(pos.x, newY, pos.z);
    }

    protected void CollectFruit(string name, string flavor, int points)
    {
        gameManager.DisplayFruitCollected(name, flavor, points);
        gameManager.UpdateScore(points);
        gameManager.fruitsCollected++;
    }
}
