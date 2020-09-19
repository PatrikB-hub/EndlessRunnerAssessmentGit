using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int amountOfLives = 3;

    public GameObject playScreen;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    public GameObject menuManager;
    private MainMenu mainMenu;

    public int gameOnOff2;

    public GameObject youLoseMenu;


    void Start()
    {
        mainMenu = menuManager.GetComponent<MainMenu>();
    }

    void Update()
    {
        // update gameOnOff2 value each frame
        gameOnOff2 = mainMenu.gameOnOff;

        int i = 1;

        //if start button pressed, (game on)
        if (gameOnOff2 == 1)
        {
            //if out of lives set gameOnOff variables to 0.
            if (amountOfLives <= 0)
            {
                mainMenu.gameOnOff = 0;
                gameOnOff2 = 0;
                i = 0;
            }
        }

        //when player dies reset lives, turn off playScreen, turn on youLoseMenu.
        if (gameOnOff2 == 0)
        {
            while (i < 1)
            {
                youLoseMenu.SetActive(true);
                playScreen.SetActive(false);
                amountOfLives =  3;
                life1.SetActive(true);
                life2.SetActive(true);
                life3.SetActive(true);
                i++;
            }

        }

    }

    //if player collides with object with tag "obstacle", -1 from amountOfLives.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            amountOfLives--;

            if (amountOfLives == 2)
            {
                life3.SetActive(false);
            }

            if (amountOfLives == 1)
            {
                life2.SetActive(false);
            }

            if (amountOfLives == 0)
            {
                life1.SetActive(false);
            }
        }
    }
}
