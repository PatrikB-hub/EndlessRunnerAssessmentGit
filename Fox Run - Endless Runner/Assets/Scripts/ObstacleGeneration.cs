using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    private int randomIndex1;

    private string platform1 = "platform01(Clone)";

    public List<GameObject> ObstaclePrefabs;

    public GameObject obstacleManager;
    public GameObject platformManager;
    private PlatformGeneration platformGeneration;

    GameObject lastPlatform1;

    public GameObject lastObstacle;

    private Vector3 objectPlacePosition = new Vector3(30f, 0f, 10f);

    // Start is called before the first frame update
    void Start()
    {

        randomIndex1 = Random.Range(0, ObstaclePrefabs.Count);
        lastObstacle = Instantiate(ObstaclePrefabs[randomIndex1], objectPlacePosition, Quaternion.identity, obstacleManager.transform);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject lastPlatform1 = platformGeneration.lastPlatform;

        for (int i = 0; i < 1; i++)
        {
            platformGeneration = GetComponent<PlatformGeneration>();
        }

        //string lastPlatformName = lastPlatform1.name;

        if (lastObstacle.transform.position.x <= 24f)
        {

            if (lastPlatform1.name == platform1)
            {
                randomIndex1 = Random.Range(0, ObstaclePrefabs.Count);

                GameObject newObstacle = Instantiate(ObstaclePrefabs[randomIndex1], obstacleManager.transform.position, Quaternion.identity, obstacleManager.transform);

                newObstacle.transform.position = objectPlacePosition;

                lastObstacle = newObstacle;
            }
        }
    }
}
