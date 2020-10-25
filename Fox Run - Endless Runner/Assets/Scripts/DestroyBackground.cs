using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBackground : MonoBehaviour
{
    private GameObject thisGO = null;
    private BackgroundGeneration backgroundGeneration;

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
        if (transform.position.x < -30f)
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
