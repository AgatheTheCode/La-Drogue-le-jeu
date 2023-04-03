using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    // Vitesse de rotation de la caméra
    public float mouseSensitivity = 100.0f;

    // Angle vertical maximal de la caméra
    public float maxVerticalAngle = 90.0f;
    // Angle vertical minimal de la caméra
    public float minVerticalAngle = -90.0f;

    // Angle vertical actuel de la caméra
    private float verticalAngle = 0.0f;

    // Objet que la caméra suit
    public GameObject cameraFollow;

    void Start()
    {
        // Cacher le curseur de la souris
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Récupérer les mouvements de la souris
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Faire tourner la caméra en fonction des mouvements de la souris sur l'axe X et Y
        transform.Rotate(Vector3.up, mouseX);
        verticalAngle -= mouseY;
        verticalAngle = Mathf.Clamp(verticalAngle, minVerticalAngle, maxVerticalAngle);
        transform.localRotation = Quaternion.Euler(verticalAngle, 0, 0);

        // Déplacer la caméra pour qu'elle suive le joueur
        transform.position = cameraFollow.transform.position;
    }
}
