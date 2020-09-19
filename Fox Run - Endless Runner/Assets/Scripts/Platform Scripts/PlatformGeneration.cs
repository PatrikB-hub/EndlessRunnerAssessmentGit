using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    private int randomIndex = 0;

    public List<GameObject> PlatformPrefabs;
    public GameObject worldParent;

    public GameObject lastPlatform;
    Vector3 plusApproximately24 = new Vector3(23.8f, 0, 0);

    private Vector3 gameStartPlatform1 = new Vector3(-24f, -1.9f, 10f);
    private Vector3 gameStartPlatform2 = new Vector3(0f, -1.9f, 10f);
    private Vector3 gameStartPlatform3 = new Vector3(24f, -1.9f, 10f);

    public int lastPlatformNumber = -1;

    public GameObject playerFox;
    private Vector3 foxStartingPositionFromScriptFCP = new Vector3(-2f, -1.5f, 10f);

    public GameObject menuManager;
    private MainMenu mainMenu;
    [SerializeField]
    private bool restarting1;
    public int h = 1;

    void Start()
    {
        StartingMenu();
        mainMenu = menuManager.GetComponent<MainMenu>();
    }

    void Update()
    {
        LastPlatformNumber();
        CorrectPlatformAfterLastPlatform();

        restarting1 = mainMenu.restarting;

        FoxMoveToStartPostion();
    }

    /// <summary>
    /// if back to main menu button is pressed, instantiate 3 new platforms(run StartingMenu()) and make player position = starting position
    /// </summary>
    public void FoxMoveToStartPostion()
    {
        if (restarting1 == false)
        {
            h = 0;
        }

        if (restarting1 == true)
        {
            if (h < 1)
            {
                StartingMenu();
                playerFox.transform.position = foxStartingPositionFromScriptFCP;
                h = 1;
            }
        }
    }

    /// <summary>
    /// instantiate 3 new platforms and set lastPlatform
    /// </summary>
    void StartingMenu()
    {
        Instantiate(PlatformPrefabs[0], gameStartPlatform1, Quaternion.identity, worldParent.transform);
        Instantiate(PlatformPrefabs[0], gameStartPlatform2, Quaternion.identity, worldParent.transform);

        lastPlatform = Instantiate(PlatformPrefabs[0], gameStartPlatform3, Quaternion.identity, worldParent.transform);
    }

    /// <summary>
    /// check lastPlatform name to assign lastPlatformNumber a value.
    /// </summary>
    public void LastPlatformNumber()
    {
        if (lastPlatform.name == "platform01(Clone)")
        {
            lastPlatformNumber = 1;
        }

        if (lastPlatform.name == "platform02(Clone)")
        {
            lastPlatformNumber = 2;
        }

        if (lastPlatform.name == "platform03(Clone)")
        {
            lastPlatformNumber = 3;
        }

        if (lastPlatform.name == "platform04(Clone)")
        {
            lastPlatformNumber = 4;
        }
    }

    /// <summary>
    /// check lastPlatformNumber value to know what platform can come after.
    /// </summary>
    public void CorrectPlatformAfterLastPlatform()
    {
        if (lastPlatformNumber == 1)
        {
            if (lastPlatform.transform.position.x < 24f)
            {
                randomIndex = Random.Range(0, 2);

                GameObject newSpawn = Instantiate(PlatformPrefabs[randomIndex], worldParent.transform.position, Quaternion.identity, worldParent.transform);

                newSpawn.transform.position = lastPlatform.transform.position + plusApproximately24;

                lastPlatform = newSpawn;
            }
        }

        if (lastPlatformNumber == 2)
        {
            if (lastPlatform.transform.position.x < 24f)
            {
                GameObject newSpawn = Instantiate(PlatformPrefabs[2], worldParent.transform.position, Quaternion.identity, worldParent.transform);

                newSpawn.transform.position = lastPlatform.transform.position + plusApproximately24;

                lastPlatform = newSpawn;
            }
        }

        if (lastPlatformNumber == 3)
        {
            if (lastPlatform.transform.position.x < 24f)
            {
                randomIndex = Random.Range(2, 4);

                GameObject newSpawn = Instantiate(PlatformPrefabs[randomIndex], worldParent.transform.position, Quaternion.identity, worldParent.transform);

                newSpawn.transform.position = lastPlatform.transform.position + plusApproximately24;

                lastPlatform = newSpawn;
            }
        }

        if (lastPlatformNumber == 4)
        {
            if (lastPlatform.transform.position.x < 24f)
            {
                GameObject newSpawn = Instantiate(PlatformPrefabs[0], worldParent.transform.position, Quaternion.identity, worldParent.transform);

                newSpawn.transform.position = lastPlatform.transform.position + plusApproximately24;

                lastPlatform = newSpawn;
            }
        }
    }

}
