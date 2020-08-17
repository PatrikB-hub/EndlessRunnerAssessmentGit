using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoveLeft : MonoBehaviour
{
    //GameObject ground;
    public float groundspeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //ground = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 groundPosition = transform.position;
        groundPosition.x -= groundspeed * Time.deltaTime;
        transform.position = groundPosition;
    }
}
