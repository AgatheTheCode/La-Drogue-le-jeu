using UnityEngine;

public class CircleSpawn : MonoBehaviour
{
    public GameObject objectToSpawn; // l'objet que l'on souhaite répliquer
    public GameObject centerCube; // le cube qui marque le centre du cercle
    public int numObjects = 25; // le nombre d'objets à répliquer
    public float radius = 100f; // le rayon du cercle

    void Start()
    {
        // boucle pour instancier les objets en cercle
        for (int i = 0; i < numObjects; i++)
        {
            // calcul de l'angle pour la position de chaque objet sur le cercle
            float angle = i * Mathf.PI * 2 / numObjects;
            Vector3 position = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;

            // instantiation de l'objet à la position calculée
            GameObject obj = Instantiate(objectToSpawn, position, Quaternion.identity);
            
            // faire tourner l'objet pour qu'il regarde vers le centre
            obj.transform.LookAt(centerCube.transform.position);
        }
    }
}