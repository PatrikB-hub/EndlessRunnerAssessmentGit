using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowFoxYAxis : MonoBehaviour
{
    public GameObject player;
    public GameObject menuManager;

    private int camSpeed = 50;

    private MainMenu mainMenu;

    private Vector3 gameMainMenuPosition= new Vector3(0f, -3f, -10f);
    private Vector3 bottomPlatformPosition = new Vector3(0f, 0.5f, -10f);
    private Vector3 topPlatformPosition = new Vector3(0f, 8.4f, -10f);

    public GameObject platformManager;
    private PlatformGeneration platformGeneration;
    private int h2;
    private int index;

    void Start()
    {
        transform.position = gameMainMenuPosition;
        platformGeneration = platformManager.GetComponent<PlatformGeneration>();
    }

    void Update()
    {
        int gameOnOffValue2 = 0;

        for (int i = 0; i < 1; i++)
        {
            mainMenu = menuManager.GetComponent<MainMenu>();
            gameOnOffValue2 = mainMenu.gameOnOff;
        }

        //if playerposition.y(PPY) < 1, cam position = bottomPlatformPosition, else if PPY > 5, cam position = topPlatformPosition,
        //else follow player position
        if (gameOnOffValue2 == 1)
        {
            if (player.transform.position.y < 1)
            {
                camSpeed = 5;
                CameraFollow(bottomPlatformPosition);
            }
            else if (player.transform.position.y > 6)
            {
                camSpeed = 5;
                CameraFollow(topPlatformPosition);
            }
            else
            {
                camSpeed = 50;
                Vector3 playerPosition = player.transform.position;
                CameraFollow(playerPosition);
            }

            index = 0;
        }

        h2 = platformGeneration.h;

        if (gameOnOffValue2 == 0)
        {
            // if player position.y < 6 then move to gameMainMenuPosition(else dont move at all)
            if (player.transform.position.y < 6)
            {
                transform.position = Vector3.MoveTowards(transform.position, gameMainMenuPosition, camSpeed * Time.deltaTime);
            }

            //when back to main menu button is pressed make camera position = gameMainMenuPosition
            if (h2 == 1)
            {
                for (index = 0; index < 1; index++)
                {
                    transform.position = gameMainMenuPosition;
                }
            }
        }
    }

    /// <summary>
    /// camera follow _tranform position
    /// </summary>
    /// <param name="_transform">position for camera to move to</param>
    private void CameraFollow(Vector3 _transform)
    {
        Vector3 playerPosition = player.transform.position;
        playerPosition.x += 2f;
        playerPosition.y += 2f;

        Vector3 camPosition = gameObject.transform.position;
        //camPosition = Vector3.MoveTowards(camPosition, playerPosition, camSpeed * Time.deltaTime);
        camPosition = Vector3.MoveTowards(camPosition, _transform, camSpeed * Time.deltaTime);
        camPosition.z = -10f;
        gameObject.transform.position = camPosition;
    }
}
