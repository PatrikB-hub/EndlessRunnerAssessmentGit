using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGeneration : MonoBehaviour
{
    public List<GameObject> backgroundPrefabs;

    public List<GameObject> backgroundMountainsFront = new List<GameObject>();
    private GameObject highestFront = null;
    public List<GameObject> backgroundMountainsMiddle = new List<GameObject>();
    private GameObject highestMiddle = null;
    public List<GameObject> backgroundMountainsBack = new List<GameObject>();
    private GameObject highestBack = null;

    private Vector3 plus30 = new Vector3(29.9f, 0, 0);

    private GameObject newBackground = null;

    void Awake()
    {
        // find first frontbackground add to backgroundMountains
        GameObject firstBackgroundFront = GameObject.Find("/Background/background_front");
        backgroundMountainsFront.Add(firstBackgroundFront);
        // find first middlebackground add to backgroundMountains
        GameObject firstBackgroundMiddle = GameObject.Find("/Background/background_middle");
        backgroundMountainsMiddle.Add(firstBackgroundMiddle);
        // find first backbackground add to backgroundMountains
        GameObject firstBackgroundBack = GameObject.Find("/Background/background_back");
        backgroundMountainsBack.Add(firstBackgroundBack);

    }

    void Update()
    {
        BackgroundCheck();

        InstantiateLowest();
    }

    private void BackgroundCheck()//check position of background GO's
    {
        //check front mountains, which is furthest to the right
        foreach (GameObject item in backgroundMountainsFront)
        {
            if (highestFront == null)
            {
                highestFront = item;
            }

            if (item.transform.position.x > highestFront.transform.position.x)
            {
                highestFront = item;
            }
        }
        //check middle mountains, which is furthest to the right
        foreach (GameObject item in backgroundMountainsMiddle)
        {
            if (highestMiddle == null)
            {
                highestMiddle = item;
            }

            if (item.transform.position.x > highestMiddle.transform.position.x)
            {
                highestMiddle = item;
            }
        }
        //check back mountains, which is furthest to the right
        foreach (GameObject item in backgroundMountainsBack)
        {
            if (highestBack == null)
            {
                highestBack = item;
            }

            if (item.transform.position.x > highestBack.transform.position.x)
            {
                highestBack = item;
            }
        }

    }


    private void InstantiateLowest()
    {
        //if the highest of front backgroung is less than 30 on x axis then instantiate a new prefab
        if (highestFront != null)
        {
            // 30 is the spawn point
            if (highestFront.transform.position.x <= 30f)
            {
                newBackground = Instantiate(backgroundPrefabs[0], (Vector3)highestFront.transform.position, Quaternion.identity, transform);
                newBackground.transform.position += plus30;
                backgroundMountainsFront.Add(newBackground);

                newBackground = null;
                highestFront = null;

            }
        }

        if (highestMiddle != null)
        {
            if (highestMiddle.transform.position.x <= 30f)
            {
                newBackground = Instantiate(backgroundPrefabs[1], (Vector3)highestMiddle.transform.position, Quaternion.identity, transform);
                newBackground.transform.position += plus30;
                backgroundMountainsMiddle.Add(newBackground);

                newBackground = null;
                highestMiddle = null;

            }
        }

        if (highestBack != null)
        {
            if (highestBack.transform.position.x <= 30f)
            {
                newBackground = Instantiate(backgroundPrefabs[2], (Vector3)highestBack.transform.position, Quaternion.identity, transform);
                newBackground.transform.position += plus30;
                backgroundMountainsBack.Add(newBackground);

                newBackground = null;
                highestBack = null;

            }
        }
    }
}
