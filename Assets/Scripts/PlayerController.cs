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

    private Rigidbody rb;

    // Vitesse de mouvement du joueur
    public float speed = 5.0f;

    // La hauteur maximale à laquelle le joueur peut sauter
    public float jumpHeight = 2.0f;

    //distance du bord
    public float edgeDistance = 1.0f;

    // Le layerMask des objets solides
    public LayerMask solidMask;

    // Objet que la caméra suit
    public Transform player;

    void Start()
    {
        //récupérer la rigidbody du joueur
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mouvement en avant et en arrière
        if (Input.GetKey(moveUpKey))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(moveDownKey))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        // Mouvement latéral
        if (Input.GetKey(moveLeftKey))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(moveRightKey))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        // Saut
        if (Input.GetKeyDown(jumpKey))
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2.0f * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }
}
