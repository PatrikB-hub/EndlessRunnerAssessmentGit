using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    public List<GameObject> PlatformPrefabs;
    public GameObject worldParent;

    public GameObject lastPlatform;
    Vector3 plusApproximately24 = new Vector3(23.8f, 0, 0);

    private Vector3 gameStartPlatform1 = new Vector3(-24f, 0f, 0f);
    private Vector3 gameStartPlatform2 = new Vector3(0f, 0f, 0f);
    private Vector3 gameStartPlatform3 = new Vector3(24f, 0f, 0f);

    void Start()
    {
        Instantiate(PlatformPrefabs[0], gameStartPlatform1, Quaternion.identity, worldParent.transform);
        Instantiate(PlatformPrefabs[0], gameStartPlatform2, Quaternion.identity, worldParent.transform);

        lastPlatform = Instantiate(PlatformPrefabs[0], gameStartPlatform3, Quaternion.identity, worldParent.transform);


    }

    void Update()
    {
        if (lastPlatform.transform.position.x < 24f)
        {
            GameObject newSpawn = Instantiate(PlatformPrefabs[0], worldParent.transform.position, Quaternion.identity, worldParent.transform);

            newSpawn.transform.position = lastPlatform.transform.position + plusApproximately24;

            lastPlatform = newSpawn;
        }

    }
}
