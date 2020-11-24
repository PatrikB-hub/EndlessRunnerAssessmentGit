using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private float disableTime = 2.5f;
    [SerializeField] private float stopScaleTime = 2f;

    private float scaleAmount;
    [SerializeField] private float startScale = 1f;
    [SerializeField] private float endScale = 0.9f;


    void Update()
    {
        if (Time.time >= disableTime)
        {
            gameObject.SetActive(false);
        }
        else
        {

            scaleAmount = Mathf.Lerp(startScale, endScale, Time.time / stopScaleTime);

            Vector3 scale = gameObject.transform.localScale;
            scale.x = scaleAmount;
            scale.y = scaleAmount;
            scale.z = scaleAmount;

            gameObject.transform.localScale = scale;
        }
    }
}
