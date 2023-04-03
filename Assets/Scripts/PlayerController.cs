using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables pour les touches préférées de l'utilisateur
    public KeyCode moveUpKey = KeyCode.W;
    public KeyCode moveDownKey = KeyCode.S;
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.Space;

    // Vitesse de mouvement du joueur
    public float speed = 5.0f;
    // Vitesse de rotation de la caméra
    public float mouseSensitivity = 100.0f;

    // Objet que la caméra suit
    public Transform player;

    // Angle vertical maximal de la caméra
    public float maxVerticalAngle = 90.0f;
    // Angle vertical minimal de la caméra
    public float minVerticalAngle = -90.0f;

    // Angle vertical actuel de la caméra
    private float verticalAngle = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // Récupérer les mouvements de la souris
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Faire tourner le joueur en fonction des mouvements de la souris sur l'axe X
        player.Rotate(Vector3.up, mouseX);

        // Faire tourner la caméra en fonction des mouvements de la souris sur l'axe Y
        verticalAngle -= mouseY;
        verticalAngle = Mathf.Clamp(verticalAngle, minVerticalAngle, maxVerticalAngle);
        transform.localRotation = Quaternion.Euler(verticalAngle, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);

        // Déplacer la caméra pour qu'elle suive le joueur
        transform.position = player.position;
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
            transform.Translate(Vector3.up * speed);
        }
    }
}
