using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalPointsText;
    [SerializeField] private TextMeshProUGUI fruitText;
    [SerializeField] private TextMeshProUGUI flavorText;
    [SerializeField] private TextMeshProUGUI fruitPointsText;
    [SerializeField] private GameObject gameOverScreen;

    private PlayerController playerController;

    private int totalPoints = 0;
    public int fruitsCollected = 0;

    [SerializeField] private List<GameObject> fruits;

    private void Start()
    {
        DisplayPoints();

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (fruitsCollected == fruits.Count)
        {
            playerController.isMovementAllowed = false;
            gameOverScreen.SetActive(true);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        totalPoints += scoreToAdd;
        DisplayPoints();
    }

    private void DisplayPoints()
    {
        totalPointsText.text = "Points: " + totalPoints;
    }

    public void DisplayFruitCollected(string fruit, string flavor, int points)
    {
        fruitText.text = "Fruit Collected: " + "\n" + fruit;
        flavorText.text = "Flavor: " + "\n" + flavor;
        fruitPointsText.text = "Points: " + "\n" + points;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
