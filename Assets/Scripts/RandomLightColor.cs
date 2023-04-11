using UnityEngine;

public class RandomLightColor : MonoBehaviour
{
    public Light[] lights; // Les spots à colorer
    public float changeInterval = 1f; // L'intervalle de changement de couleur en secondes
    public float maxColorChange = 1f; // La valeur maximale de changement de couleur sur chaque canal RGB

    private float timeElapsed = 0f; // Le temps écoulé depuis le dernier changement de couleur

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= changeInterval)
        {
            // Réinitialiser le temps écoulé
            timeElapsed = 0f;

            // Pour chaque spot
            foreach (Light light in lights)
            {
                // Générer un changement de couleur aléatoire sur chaque canal RGB
                Color currentColor = light.color;
                Color newColor = new Color(
                    Mathf.Clamp(currentColor.r + Random.Range(-maxColorChange, maxColorChange), 0f, 1f),
                    Mathf.Clamp(currentColor.g + Random.Range(-maxColorChange, maxColorChange), 0f, 1f),
                    Mathf.Clamp(currentColor.b + Random.Range(-maxColorChange, maxColorChange), 0f, 1f)
                );

                // Appliquer la nouvelle couleur
                light.color = newColor;
            }
        }
    }
}
