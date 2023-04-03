using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Vitesse de rotation de la caméra
    public float mouseSensitivity = 100.0f;

    // Objet que la caméra suit
    public Transform player;

    // L'angle maximal que la caméra peut atteindre
    public float maxAngle = 90.0f;

    // L'angle minimal que la caméra peut atteindre
    public float minAngle = -90.0f;

    // L'angle actuel de la caméra
    private float currentAngle = 0.0f;

    // Récupération de la position de la souris
    private float mouseX = 0.0f;
    private float mouseY = 0.0f;

    void Start()
    {
        // Rendre le curseur invisible et verrouiller sa position
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Récupérer la position de la souris
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Limiter l'angle de la caméra
        mouseY = Mathf.Clamp(mouseY, minAngle, maxAngle);

        // Appliquer la rotation à la caméra
        transform.eulerAngles = new Vector3(mouseY, mouseX, 0.0f);

        // Appliquer la position de la caméra à l'objet suivi
        transform.position = player.position;
    }
}
