using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    public Joystick joystick;
    public float throttle;
    public float torque;

    private new Rigidbody rigidbody;
    private float torqueInput;
    private float throttleInput;
    private new Camera camera;

    public GameObject rocket;

    public GameObject effect;

    public Button tryAgain;

    public Button mainMenu;
    public Text lose;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        GameData.score = 0;
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float height = camera.orthographicSize;
        float width = height * camera.aspect;
        torqueInput = joystick.Horizontal;
        throttleInput = joystick.Vertical;
        if (Mathf.Abs(transform.position.x) > width)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
        if (Mathf.Abs(transform.position.z) > height)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -transform.position.z);
        }
        transform.Rotate(0, 0, -torque * Time.deltaTime * torqueInput);



    }
    public void Shoot()
    {
        GameObject r = Instantiate(rocket, transform.position, transform.rotation);
    }
    void FixedUpdate()
    {
        rigidbody.AddRelativeForce(Vector3.up * throttleInput * throttle, ForceMode.Force);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.name == "Rocket(Clone)"))
        {
            GameObject.Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            tryAgain.gameObject.SetActive(true);
            lose.gameObject.SetActive(true);
            mainMenu.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("highScore", 0) < GameData.score)
                PlayerPrefs.SetInt("highScore", GameData.score);
            Time.timeScale = 0;
            
        }
    }

}
