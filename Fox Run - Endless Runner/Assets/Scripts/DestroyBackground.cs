using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBackground : MonoBehaviour
{
    private GameObject thisGO = null;
    private BackgroundGeneration backgroundGeneration;

    private int destroyPoint = -50;

    private void Start()
    {
        thisGO = gameObject;
        backgroundGeneration = thisGO.GetComponentInParent<BackgroundGeneration>();
    }

    private void Update()
    {
        destroyBackgroundGO();    
    }

    private void destroyBackgroundGO()
    {
        //if this gameobject.x is less than the destroy point, check which list it is in, remove it and destroy it.
        if (transform.position.x < destroyPoint)
        {
            if (backgroundGeneration.backgroundMountainsFront.Contains(gameObject))
            {
                backgroundGeneration.backgroundMountainsFront.Remove(gameObject);
                Destroy(gameObject);
            }
            if (backgroundGeneration.backgroundMountainsMiddle.Contains(gameObject))
            {
                backgroundGeneration.backgroundMountainsMiddle.Remove(gameObject);
                Destroy(gameObject);
            }
            if (backgroundGeneration.backgroundMountainsBack.Contains(gameObject))
            {
                backgroundGeneration.backgroundMountainsBack.Remove(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
