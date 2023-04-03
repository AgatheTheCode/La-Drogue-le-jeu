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

    private Rigidbody rb;
    private Camera cam;

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
        // Mouvement en avant et en arrière
        if (Input.GetKey(moveUpKey))
        {
            transform.position += cam.transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(moveDownKey))
        {
            transform.position -= cam.transform.forward * Time.deltaTime * speed;
        }

        // Mouvement latéral
        if (Input.GetKey(moveLeftKey))
        {
            transform.position -= cam.transform.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(moveRightKey))
        {
            transform.position += cam.transform.right * Time.deltaTime * speed;
        }

        // Saut
        if (Input.GetKeyDown(jumpKey))
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2.0f * Physics.gravity.y), ForceMode.VelocityChange);
        }

        // Sprint
        if (Input.GetKey(sprintKey))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = 5.0f;
        }
    }
}
