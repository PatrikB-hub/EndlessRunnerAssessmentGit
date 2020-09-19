using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtCertainPosition : MonoBehaviour
{
    // if gameObject.transform.position.x <= 48 destroy it.
    void Update()
    {
        if (gameObject.transform.position.x <= -48f)
        {
            Destroy(gameObject);
        }
    }
}
