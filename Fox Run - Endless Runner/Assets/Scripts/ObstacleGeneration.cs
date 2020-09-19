using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    private int randomIndex1;

    public List<GameObject> ObstaclePrefabs;

    public GameObject obstacleManager;
    public GameObject platformManager;
    private PlatformGeneration platformGeneration;

    private int lastPlatformNumber1 = 0;

    public GameObject lastObstacle;
    public GameObject destroyErrorSaveObject;

    private Vector3 objectPlaceAtBottomPosition = new Vector3(40f, -1.7f, 11f);
    private Vector3 objectPlaceAtTopPosition = new Vector3(40f, 6.2f, 11f);

    void Start()
    {
        platformGeneration = platformManager.GetComponent<PlatformGeneration>();

        randomIndex1 = Random.Range(0, ObstaclePrefabs.Count);
        //first lastObstacle in game.
        lastObstacle = Instantiate(ObstaclePrefabs[randomIndex1], objectPlaceAtBottomPosition, Quaternion.identity, obstacleManager.transform);
    }

    void Update()
    {
        // get value of lastPlatformNumber (each frame)
        lastPlatformNumber1 = platformGeneration.lastPlatformNumber;

        //if lastPlatformNumber1 = 1st platform, instance a random obstacle from ObsaclePrefabs
        if (lastPlatformNumber1 == 1)
        {
            if (lastObstacle.transform.position.x <= 24f)
            {
                randomIndex1 = Random.Range(0, ObstaclePrefabs.Count);

                GameObject newObstacle = Instantiate(ObstaclePrefabs[randomIndex1], obstacleManager.transform.position, Quaternion.identity, obstacleManager.transform);

                newObstacle.transform.position = objectPlaceAtBottomPosition;

                lastObstacle = newObstacle;
            }
        }

        //if lastPlatformNumber1 = 3rd platform, instance a random obstacle from ObsaclePrefabs
        if (lastPlatformNumber1 == 3)
        {
            if (lastObstacle.transform.position.x <= 24f)
            {
                randomIndex1 = Random.Range(0, ObstaclePrefabs.Count);

                GameObject newObstacle = Instantiate(ObstaclePrefabs[randomIndex1], obstacleManager.transform.position, Quaternion.identity, obstacleManager.transform);

                newObstacle.transform.position = objectPlaceAtTopPosition;

                lastObstacle = newObstacle;
            }
        }

        //if there is no objet to reference make lastObstacle = destroyErrorSaveObject
        if (lastObstacle == null)
        {
            lastObstacle = destroyErrorSaveObject;
        }
    }
}
