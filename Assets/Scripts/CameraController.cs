using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
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

        // Faire tourner la caméra en fonction des mouvements de la souris sur l'axe Y
        verticalAngle -= mouseY;
        verticalAngle = Mathf.Clamp(verticalAngle, minVerticalAngle, maxVerticalAngle);
        transform.localRotation = Quaternion.Euler(verticalAngle, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
    }
}
