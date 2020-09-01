using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowFoxYAxis : MonoBehaviour
{
    public GameObject player;
    public GameObject camera;

    public float bottomboundary = -1;
    public int rasiedCameraPosition = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //finding player position
        //Vector2 playerposition = player.transform.position;
        //Debug.Log(player.transform.position.y);

        //if player pos is less than (bottomboundary), camera y = player y value
        if (player.transform.position.y < bottomboundary)
        {
            //replace y value of camera with player y value

            Vector3 cameraposition = camera.transform.position;
            cameraposition.y = player.transform.position.y + rasiedCameraPosition;
            camera.transform.position = cameraposition;

        }
    }
}
