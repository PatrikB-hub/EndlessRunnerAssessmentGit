using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FoxConstantPosition : MonoBehaviour
{
    private int foxGeneralPosition = -2;

    public float foxReturnSpeed = 1f;

    public GameObject menuManager;
    private MainMenu mainMenu;

    private bool foxGeneralPositionStart = false;

    private Vector3 foxRunToWhenStartIsPressedPosition = new Vector3(3.5f, -1.5f, 10f);
    private Vector3 foxStartingPosition = new Vector3(-2f, -1.5f, 10f);

    private void Start()
    {
        transform.position = foxStartingPosition;
    }

    void Update()
    {
        int gameOnOffValue1 = 0;

        //assign/link gameOnOffValue1 to menuManager/ gameOnOff value.
        for (int i = 0; i < 1; i++)
        {
            mainMenu = menuManager.GetComponent<MainMenu>();
            gameOnOffValue1 = mainMenu.gameOnOff;
        }

        //when gameOnOffValue1 = 0, fox return to original pos.
        if (gameOnOffValue1 == 0)
        {
            foxGeneralPositionStart = false;

            if (transform.position.y < 5)
            {
                transform.position = foxStartingPosition;
                transform.rotation = Quaternion.identity;
            }

        }

        //when gameOnOffValue1 = 1, go to foxRunToWhenStartIsPressedPosition, then to 4<x<4.
        if (gameOnOffValue1 == 1)
        {
            if (foxGeneralPositionStart == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, foxRunToWhenStartIsPressedPosition, foxReturnSpeed * 5 * Time.deltaTime);
                if (transform.position.x > 3f)
                {
                    foxGeneralPositionStart = true;
                }
            }

            if (foxGeneralPositionStart == true)
            {
                //when fox x-position < -2f move right approaching x=-2
                if (transform.position.x < foxGeneralPosition)
                {
                    Vector3 playerposition = transform.position;
                    playerposition.x += foxReturnSpeed * Time.deltaTime;
                    transform.position = playerposition;
                }

                //when fox x-position > -2f move left approaching x=-2
                if (transform.position.x > foxGeneralPosition)
                {
                    Vector3 playerposition = transform.position;
                    playerposition.x -= foxReturnSpeed * Time.deltaTime;
                    transform.position = playerposition;
                }
            }
        }

    }
}
