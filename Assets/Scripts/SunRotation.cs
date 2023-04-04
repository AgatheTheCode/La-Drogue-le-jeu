using UnityEngine;

public class SunRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;  // Vitesse de rotation en degrés par minute

    private float currentRotation = 0f;
    private float rotationTarget = 0f;
    private float rotationStep = 0f;

    void Start()
    {
        // Calculer la rotation cible initiale
        rotationTarget = transform.rotation.eulerAngles.y + 10f;
        if (rotationTarget > 360f)
        {
            rotationTarget -= 360f;
        }
    }

    void Update()
    {
        // Calculer la rotation actuelle
        currentRotation = transform.rotation.eulerAngles.y;

        // Calculer la rotation restante pour atteindre la cible
        float rotationRemaining = rotationTarget - currentRotation;

        // Vérifier si la rotation est terminée
        if (Mathf.Abs(rotationRemaining) <= 0.01f)
        {
            // Définir une nouvelle cible de rotation
            rotationTarget += 10f;
            if (rotationTarget > 360f)
            {
                rotationTarget -= 360f;
            }

            // Calculer le pas de rotation pour atteindre la cible
            rotationStep = rotationSpeed * Time.deltaTime;
            if (Mathf.Abs(rotationStep) > Mathf.Abs(rotationRemaining))
            {
                rotationStep = rotationRemaining;
            }
        }

        // Faire tourner la Directional Light vers la cible
        transform.Rotate(Vector3.up, rotationStep);
    }
}
