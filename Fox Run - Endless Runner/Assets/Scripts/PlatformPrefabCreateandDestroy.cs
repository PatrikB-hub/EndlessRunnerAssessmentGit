using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPrefabCreateandDestroy : MonoBehaviour
{
    /*
    public List<GameObject> PlatformPrefabs;

    public GameObject platformManager;

    private Vector3 lastPlatformCheckPoint = new Vector3(24f, -1.9f, 10f);

    GameObject lastPlatformGO;
    GroundMoveLeft lastPlatform;

    private Vector3 gameStartPlatform1 = new Vector3(-24f, -1.9f, 10f);
    private Vector3 gameStartPlatform2 = new Vector3(0f, -1.9f, 10f);
    private Vector3 gameStartPlatform3 = new Vector3(24f, -1.9f, 10f);


    void Start()
    {
        
        //Instantiate(PlatformPrefabs[0], gameStartPlatform1, Quaternion.identity, platformManager.transform);
        //Instantiate(PlatformPrefabs[0], gameStartPlatform2, Quaternion.identity, platformManager.transform);
        lastPlatformGO = Instantiate(PlatformPrefabs[0],
                                        gameStartPlatform3,
                                        Quaternion.identity, 
                                        platformManager.transform);
        lastPlatform = lastPlatformGO.GetComponent<GroundMoveLeft>();


    }
    
    void Update()
    {
        
        if (lastPlatform.lastPlatformPosition.x <= lastPlatformCheckPoint.x)
        {
            int randomIndex = Random.Range(0, PlatformPrefabs.Count);

            GameObject newSpawn = Instantiate(PlatformPrefabs[randomIndex],
                                                lastPlatform.lastPlatformPosition,
                                                Quaternion.identity,
                                                platformManager.transform);
            GroundMoveLeft newPlatform = newSpawn.GetComponent<GroundMoveLeft>();


            newSpawn.transform.position = lastPlatform.lastPlatformPosition + lastPlatformCheckPoint;
            lastPlatform = newPlatform;
        }
        
    }
    */
}
