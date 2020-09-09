using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowFoxYAxis : MonoBehaviour
{
    public GameObject player;
    public GameObject menuManager;

    private int camSpeed = 3;

    private MainMenu mainMenu;

    private Vector3 gameMainMenuPosition= new Vector3(0f, -3f, -10f);

    void Start()
    {
        transform.position = gameMainMenuPosition;
    }

    void Update()
    {
        
        int gameOnOffValue2 = 0;

        for (int i = 0; i < 1; i++)
        {
            mainMenu = menuManager.GetComponent<MainMenu>();
            gameOnOffValue2 = mainMenu.gameOnOff;
        }

        if (gameOnOffValue2 == 1)
        {
            Vector3 playerPosition = player.transform.position;
            playerPosition.x += 2f;
            playerPosition.y += 2.5f;

            Vector3 camPosition = gameObject.transform.position;
            camPosition = Vector3.MoveTowards(camPosition, playerPosition, camSpeed * Time.deltaTime);
            camPosition.z = -10f;
            gameObject.transform.position = camPosition;
        }

        if (gameOnOffValue2 == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, gameMainMenuPosition, camSpeed * Time.deltaTime);
        }
        
    }
}
