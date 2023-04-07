using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrobeLight : MonoBehaviour
{
    public float maxRotationAngle = 15f; // L'angle maximal de rotation sur chaque axe

    void Update()
    {
        // Calculer une rotation aléatoire sur chaque axe
        float randomRotationX = Random.Range(-maxRotationAngle, maxRotationAngle);
        float randomRotationY = Random.Range(-maxRotationAngle, maxRotationAngle);
        float randomRotationZ = Random.Range(-maxRotationAngle, maxRotationAngle);

        // Créer une rotation à partir des angles aléatoires
        Quaternion randomRotation = Quaternion.Euler(randomRotationX, randomRotationY, randomRotationZ);

        // Appliquer la rotation à l'objet
        transform.rotation *= randomRotation;
    }
}
