using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnythingMovLeft : MonoBehaviour
{
    private GameObject menuManager;
    private MainMenu mainMenu;

    [SerializeField]
    private int gameOnOffValue1;

    void Start()
    {
        menuManager = GameObject.Find("/MenuManager");
        mainMenu = menuManager.GetComponent<MainMenu>();
    }

    private void Update()
    {
        gameOnOffValue1 = mainMenu.gameOnOff;

        if (gameOnOffValue1 == 1)
        {
            if (transform.position.z == 11.5f)// global z-pos of front mountain
            {
                AnythingMovingLeft(7f);//front mountain moves faster than further back mountains(same for next 2)
            }
            if (transform.position.z == 12f)// global z-pos of middle mountain
            {
                AnythingMovingLeft(5f);
            }
            if (transform.position.z == 13f)// global z-pos of back mountain
            {
                AnythingMovingLeft(3f);
            }
        }

    }

    private void AnythingMovingLeft(float _moveSpeed)
    {
        Vector3 objectPosition = transform.position;
        objectPosition.x -= _moveSpeed * Time.deltaTime;
        transform.position = objectPosition;
        
    }
}
