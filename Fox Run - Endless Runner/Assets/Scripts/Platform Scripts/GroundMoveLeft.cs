using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoveLeft : MonoBehaviour
{
    private float groundSpeed = 0;

    public MainMenu mainMenu;


    void Start()
    {
        //groundSpeed = 0f;
    }

    public void Update()
    {
        int gameOnOffValue = 0;

        for (int i = 0; i < 1; i++)
        {
            GameObject menuManager = GameObject.Find("/MenuManager");
            mainMenu = menuManager.GetComponent<MainMenu>();
            gameOnOffValue = mainMenu.gameOnOff;
        }
        
        if (gameOnOffValue == 1)
        {
            StartButtonPressed();
            GroundMovingLeft();
        }
    }

    void GroundMovingLeft()
    {
        Vector3 groundPosition = gameObject.transform.position;
        groundPosition.x -= groundSpeed * Time.deltaTime;
        transform.position = groundPosition;
    }

    void StartButtonPressed()
    {
        if (groundSpeed == 0)
        {
            groundSpeed = 10f;
        }
    }
    
}
