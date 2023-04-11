using UnityEngine;

public class SunRotation : MonoBehaviour
{

    public float rotationSpeed = .1f; // La vitesse de rotation

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

