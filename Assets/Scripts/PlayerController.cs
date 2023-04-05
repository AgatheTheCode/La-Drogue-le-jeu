using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables pour les touches préférées de l'utilisateur
    public KeyCode moveUpKey = KeyCode.Z;
    public KeyCode moveDownKey = KeyCode.S;
    public KeyCode moveLeftKey = KeyCode.Q;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;

    // Variables pour les entrées de la manette
    public string joystickHorizontalAxis = "Horizontal";
    public string joystickVerticalAxis = "Vertical";
    public string joystickJumpButton = "Jump";
    public string joystickSprintButton = "Fire3";

    private Rigidbody rb;
    private Camera cam;
    private bool canJump = true;

    // Vitesse de mouvement du joueur
    public float speed = 5.0f;
    public float sprintSpeed = 10.0f;

    // La hauteur maximale à laquelle le joueur peut sauter
    public float jumpHeight = 2.0f;

    //distance du bord
    public float edgeDistance = 1.0f;

    // Le layerMask des objets solides
    public LayerMask solidMask;

    void Start()
    {
        //récupérer la rigidbody du joueur
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mouvement en avant et en arrière (clavier ou manette)
        float verticalInput = Input.GetAxis(joystickVerticalAxis);
        if (Input.GetKey(moveUpKey) || verticalInput > 0)
        {
            transform.position += cam.transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(moveDownKey) || verticalInput < 0)
        {
            transform.position -= cam.transform.forward * Time.deltaTime * speed;
        }

        // Mouvement latéral (clavier ou manette)
        float horizontalInput = Input.GetAxis(joystickHorizontalAxis);
        if (Input.GetKey(moveLeftKey) || horizontalInput < 0)
        {
            transform.position -= cam.transform.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(moveRightKey) || horizontalInput > 0)
        {
            transform.position += cam.transform.right * Time.deltaTime * speed;
        }

        // Saut (clavier ou manette)
        if ((Input.GetKeyDown(jumpKey) || Input.GetButtonDown(joystickJumpButton)) && canJump)
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2.0f * Physics.gravity.y), ForceMode.VelocityChange);
            canJump = false;
            StartCoroutine(ResetJump());
        }

        // Sprint (clavier ou manette)
        if (Input.GetKey(sprintKey) || Input.GetButton(joystickSprintButton))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = 5.0f;
        }
    }

    IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(2.5f);
        canJump = true;
    }
}
