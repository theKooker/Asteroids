using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMovement : MonoBehaviour
{

    private float settings;
    private Camera camera;

    void Start()
    {
        camera = Camera.main;
        settings = camera.orthographicSize * camera.aspect * 2;

    }
    // Update is called once per frame
    void Update()
    {
        var height = camera.orthographicSize;
        var width = height * camera.aspect;
        gameObject.transform.Translate(Vector3.right * Time.deltaTime);
        transform.localScale = new Vector3(width * 2 + 1, height * 2 + 1, transform.localScale.z);

        if (gameObject.transform.position.x > settings)
        {
            gameObject.transform.position = new Vector3(-settings, transform.position.y, transform.position.z);
        }
    }
}
