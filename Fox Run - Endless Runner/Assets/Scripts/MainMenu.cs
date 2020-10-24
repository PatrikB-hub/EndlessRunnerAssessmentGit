using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public bool restarting = false;

    public int gameOnOff = 0;

    public GameObject playScreen;

    public int highScore;
    public float score = 0;
    public float roundedScore = 0;
    public string scoreString;
    public string highScoreString;

    public GameObject platformManager;
    private GameObject destroyPlatform;
    private int amountOfPlatformsToDestroy;
    private int amountOfPlatformsDestroyed;

    public GameObject obstacleManager;
    private GameObject destroyObstacle;
    public int amountOfObstaclesToDestroy;
    public int amountOfObstaclesDestroyed;


    private void Start()
    {
        //a number > 4 as there are only ever 4 platforms in play.
        amountOfPlatformsDestroyed = 5;
        //a number > 8 as there are only ever (< 8) obstacles in play.
        amountOfObstaclesDestroyed = 8;
    }

    private void Update()
    {
        int i = -1;
        //when start button is pressed
        if (gameOnOff == 1)
        {
            //score plus 4 multiplyed by 1/50 to make player move 24m/s (or something like that).
            score = score + 4 * 0.02f;
            roundedScore = score;
            //when score > 50 round to int
            if (score > 50)
            {
                roundedScore = Mathf.Round(score);
            }
            //compile scoreString
            scoreString = "Score:" + " " + roundedScore + "m";
            while (i != 0)
            {
                i = 0;
            }
        }

        //when player dies
        if (gameOnOff == 0)
        {
            // when gameOnOff = 0, if score > highScore, highScore can be set to score.
            if (score > highScore)
            {
                for (i = 0; i < 1; i++)
                {
                    highScore = (int)score;
                    highScoreString = "Highscore" + " " + highScore + "m";
                }
            }
            //reset score for next round
            score = 0;
        }

        //when back to main menu button is pressed.
        if (restarting == true)
        {
            if (amountOfPlatformsDestroyed < amountOfPlatformsToDestroy)
            {
                //make next platform with "platform" tag = destroyPlatform.
                if (destroyPlatform == null)
                {
                    destroyPlatform = GameObject.FindWithTag("platform");
                }
                //destroy the platform next frame
                Destroy(destroyPlatform);
                //make room for next platform
                destroyPlatform = null;
                amountOfPlatformsDestroyed++;
            }

            if (amountOfObstaclesDestroyed < amountOfObstaclesToDestroy - 1)
            {
                //make next obstacle with "platform" tag = destroyObstacle.
                if (destroyObstacle == null)
                {
                    destroyObstacle = GameObject.FindWithTag("obstacle");
                }
                //destroy the obstacle next frame
                Destroy(destroyObstacle);
                //make room for next obstacle
                destroyObstacle = null;
                amountOfObstaclesDestroyed++;
            }
        }
    }

    public void StartGame()
    {
        //startGame = true;
        gameOnOff = 1;
        // display fox lives
        playScreen.SetActive(true);
        restarting = false;
    }

    private void OnGUI()
    {
        //if gameOnOff = 1 display Label "scoreString"
        if (gameOnOff == 1)
        {
            GUIStyle style = GUI.skin.GetStyle("label");

            style.fontSize = 30;

            GUI.Label(new Rect((Screen.width * 0.5f) - 500, 40, 1000, 500), scoreString);
        }

        //if gameOnOff = 0 display Label "highScoreString"
        if (gameOnOff == 0)
        {
            GUIStyle style = GUI.skin.GetStyle("label");

            style.fontSize = 30;

            GUI.Label(new Rect((Screen.width * 0.5f) - 500, 40, 1000, 500), highScoreString);
        }

    }

    public void RestartMethod()
    {
        //find how many platforms to destroy
        amountOfPlatformsToDestroy = platformManager.transform.childCount;
        //set destroyed platforms to 0.
        amountOfPlatformsDestroyed = 0;
        //find how many obstacles to destroy
        amountOfObstaclesToDestroy = obstacleManager.transform.childCount;
        //set destroyed obstacles to 0
        amountOfObstaclesDestroyed = 0;

        restarting = true;

    }

}
