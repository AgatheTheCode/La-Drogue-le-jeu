using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class DiscoBaby : MonoBehaviour
{
    public float rotationSpeed = 50f; // La vitesse de rotation de la boule

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime); // Fait tourner la boule autour de son axe Y
    }
}
