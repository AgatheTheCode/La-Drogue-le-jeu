using UnityEngine;

public class DiscoBaby : MonoBehaviour
{
    public float rotationSpeed = 50f; // La vitesse de rotation de la boule
    public float xRotationSpeed = 0f; // La vitesse de rotation de la boule autour de l'axe X
    public float yRotationSpeed = 0f; // La vitesse de rotation de la boule autour de l'axe Y
    public float zRotationSpeed = 0f; // La vitesse de rotation de la boule autour de l'axe Z

    void Update()
    {
        // Crée une rotation à partir des angles de rotation souhaités
        Quaternion additionalRotation = Quaternion.Euler(xRotationSpeed * Time.deltaTime, yRotationSpeed * Time.deltaTime, zRotationSpeed * Time.deltaTime);

        // Multiplie la rotation actuelle de la boule par la rotation supplémentaire
        transform.rotation *= additionalRotation;

        // Fait tourner la boule autour de son axe Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
