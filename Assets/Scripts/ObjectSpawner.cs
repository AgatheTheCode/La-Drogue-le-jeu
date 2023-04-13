using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // l'objet à instancier
        public GameObject objectToSpawn2; // l'objet à instancier
    public float spawnDelay = 10f; // le délai entre chaque spawn
    private float timeSinceLastSpawn; // le temps écoulé depuis le dernier spawn

    void Update()
    {
        // Incrémente le temps écoulé depuis le dernier spawn
        timeSinceLastSpawn += Time.deltaTime;

        // Si le temps écoulé est supérieur ou égal au délai de spawn
        if (timeSinceLastSpawn >= spawnDelay)
        {
            // Réinitialise le temps écoulé depuis le dernier spawn
            timeSinceLastSpawn = 0f;

            // Instancie l'objet à la position du spawner avec la rotation par défaut
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            Instantiate(objectToSpawn2, transform.position, Quaternion.identity);
        }
    }
}
