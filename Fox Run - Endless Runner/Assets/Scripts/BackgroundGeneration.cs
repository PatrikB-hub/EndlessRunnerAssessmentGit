using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGeneration : MonoBehaviour
{
    public List<GameObject> backgroundPrefabs;

    private List<GameObject> backgroundMountains = new List<GameObject>();

    private List<GameObject> backgroundMountainsLessThan30 = new List<GameObject>();

    private GameObject lowest = null;

    void Start()
    {
        GameObject firstBackgroundFront = GameObject.Find("/Background/background_front");
        backgroundMountains.Add(firstBackgroundFront);
        GameObject firstBackgroundMiddle = GameObject.Find("/Background/background_middle");
        backgroundMountains.Add(firstBackgroundMiddle);
        GameObject firstBackgroundBack = GameObject.Find("/Background/background_back");
        backgroundMountains.Add(firstBackgroundBack);

    }

    void Update()
    {
        BackgroundCheck();
    }

    private void BackgroundCheck()//check position of background GO's
    {
        foreach (GameObject item in backgroundMountains)
        {
            /*
            if ()
            {

            }
            */
            if (item.transform.position.x < 30)
            {
                backgroundMountainsLessThan30.Add(item);
            }
        }

        foreach (GameObject item in backgroundMountainsLessThan30)
        {
            for (int i = 0; i < 1; i++)
            {
                lowest = item;
            }

            if (item.transform.position.x < lowest.transform.position.x)
            {
                lowest = item;
            }
        }

        Instantiate(backgroundPrefabs[0], (Vector3)lowest.transform.position, Quaternion.identity, transform);

    }




    //check if any backgroundMountains gameobjects are !> than 30

    // true = check z position, instantiate correct prefab, copy tranform position 


    //find positions of any objects that are greater than 30
    //assign them to a new list
    //find object with lowest y value
    //assign a variable to this object
    //obtain z position
    //if this object has a y value <= 30 then instantiate correct prefab depending on z value
    //
}
