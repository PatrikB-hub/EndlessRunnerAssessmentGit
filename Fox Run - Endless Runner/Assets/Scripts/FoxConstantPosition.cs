using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//[RequireComponent(typeof(Rigidbody2D))]
public class FoxConstantPosition : MonoBehaviour
{
    public int foxgeneralposition = -4;

    public float foxreturnspeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //when fox x-position < -4f move right approaching x=4
        if (transform.position.x < foxgeneralposition)
        {
            Vector2 playerposition = transform.position;
            playerposition.x += foxreturnspeed * Time.deltaTime;
            transform.position = playerposition;
        }

        //when fox x-position > -4f move left approaching x=4
        if (transform.position.x > foxgeneralposition)
        {
            Vector2 playerposition = transform.position;
            playerposition.x -= foxreturnspeed * Time.deltaTime;
            transform.position = playerposition;
        }
    }
}
