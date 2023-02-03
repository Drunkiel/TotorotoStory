using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedForce;
    public float rotationForce;
    private float yRotation;
    public static bool stopPlayer;

    public Transform groundTester;
    public float radius;
    public LayerMask layerMask;
    public bool onTheGround;
    private Vector3 velocity;

    public Transform playerCamera;
    public CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(groundTester.position, radius, layerMask);

        if (colliders.Length > 0) onTheGround = true;
        else onTheGround = false;

        if (onTheGround) velocity.y = 0f;
        if (!onTheGround) Gravity();

        if (!stopPlayer)
        {
            Movement();
            Rotate();
        }
    }

    void Movement()
    {
        //Inicjalizing inputs
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * -vertical;

        _characterController.Move(move * speedForce * Time.deltaTime);
    }

    void Gravity()
    {
        velocity.y += Physics.gravity.y * Time.deltaTime;

        _characterController.Move(velocity * Time.deltaTime);
    }

    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationForce * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationForce * Time.deltaTime;

        yRotation += mouseY;
        yRotation = Mathf.Clamp(yRotation, -110, -70);

        playerCamera.localRotation = Quaternion.Euler(0, yRotation, -90f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
