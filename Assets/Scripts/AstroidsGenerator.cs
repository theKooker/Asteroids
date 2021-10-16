using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidsGenerator : MonoBehaviour
{
    public List<GameObject> prefabs;

    private Camera camera;
    private float height, width;

    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        height = camera.orthographicSize;
        width = height * camera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (count > 100)
        {
            int index = Random.Range(0, prefabs.Count);
            float x = Random.Range(-width + 1, width - 1);
            float[]  arr= {-height,height};

            Instantiate(prefabs[index], new Vector3(x,0,arr[Random.Range(0,2)]), Quaternion.identity);
            count = 0;
        }
        count++;

    }
}
