using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public float maxRotationAngle = 45f; // L'angle maximal de rotation sur chaque axe
    public float rotationSpeed = 5f; // La vitesse de rotation de l'objet

    private Quaternion targetRotation; // La rotation cible vers laquelle l'objet doit tourner
    private bool changingDirection = false; // Un indicateur pour savoir si l'objet doit changer de direction

    void Start()
    {
        // Initialiser la rotation cible avec une rotation aléatoire
        targetRotation = GetRandomRotation();
    }

    void Update()
    {
        // Si l'objet n'est pas en train de changer de direction
        if (!changingDirection)
        {
            // Si la différence angulaire entre la rotation courante et la rotation cible est inférieure à l'angle maximal
            if (Quaternion.Angle(transform.rotation, targetRotation) < maxRotationAngle)
            {
                // Changer de direction en initialisant la rotation cible avec une nouvelle rotation aléatoire
                targetRotation = GetRandomRotation();
                changingDirection = true;
            }
        }
        else // Si l'objet est en train de changer de direction
        {
            // Si la différence angulaire entre la rotation courante et la rotation cible est inférieure à une petite marge d'erreur
            if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
            {
                // Arrêter le changement de direction en réinitialisant l'indicateur
                changingDirection = false;
            }
        }

        // Faire tourner l'objet progressivement vers la rotation cible à la vitesse spécifiée
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    Quaternion GetRandomRotation()
    {
        float x = Random.Range(-180f, 180f);
        float y = Random.Range(-45f, 45f);
        float z = Random.Range(-180f, 180f);

        return Quaternion.Euler(x, y, z);
    }
}
