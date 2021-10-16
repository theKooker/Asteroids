
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidMovement : MonoBehaviour
{
    public float RotationSpeed;
    public float DriftingSpeed;

    private Vector3 rotationAxis;
    private Vector3 driftingDirection;
    private Camera camera;

    public GameObject effect;

    public GameObject small;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        rotationAxis = new Vector3(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100)).normalized;
        driftingDirection = new Vector3(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100)).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(driftingDirection * DriftingSpeed * Time.deltaTime);
        transform.Rotate(rotationAxis, RotationSpeed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        var height = camera.orthographicSize;
        var width = height * camera.aspect;
        if (Mathf.Abs(transform.position.x) > width + 5)
        {
            Destroy(gameObject);
        }
        if (Mathf.Abs(transform.position.z) > height + 5)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);
        Instantiate(effect, transform.position, new Quaternion(0,0,0,1));
        if (gameObject.tag == "Big")
        {
            
            Instantiate(small, transform.position + Vector3.up, Quaternion.identity);
            Instantiate(small, transform.position + new Vector3(0, 1, 2), Quaternion.identity);
        } 
        
        if(other.gameObject.tag == "Shoot") {
            GameData.score += (gameObject.tag == "Big" ? 10 :5);
            Destroy(other.gameObject);
        }
    }
}
