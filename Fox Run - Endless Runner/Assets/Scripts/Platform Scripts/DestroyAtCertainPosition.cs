using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtCertainPosition : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (gameObject.transform.position.x <= -48f)
        {
            Destroy(gameObject);
        }
    }
}
