using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public float speed;
    private Camera camera;
    void Start()
    {
        camera = Camera.main;

    }
    // Update is called once per frame
    void Update()
    {
        var height = camera.orthographicSize;
        var width = height * camera.aspect;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.x) > width)
        {
            Destroy(gameObject);
        }
        if (Mathf.Abs(transform.position.z) > height)
        {
            Destroy(gameObject);
        }
    }
}
