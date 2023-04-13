using UnityEngine;
using System.Collections;

public class GyroLight : MonoBehaviour
{
    public Light light1; // La première lumière
    public Light light2; // La seconde lumière
    public float flashInterval = 0.5f; // L'intervalle entre chaque clignotement

    private bool isLight1On = true; // Indique si la première lumière est allumée

    void Start()
    {
        // Démarrage de la coroutine qui gère les clignotements
        StartCoroutine(FlashLights());
    }

    IEnumerator FlashLights()
    {
        while (true)
        {
            // Alterne les lumières en fonction du timer
            if (isLight1On)
            {
                light1.enabled = true;
                light2.enabled = false;
                isLight1On = false;
            }
            else
            {
                light1.enabled = false;
                light2.enabled = true;
                isLight1On = true;
            }

            // Attend l'intervalle spécifié avant de recommencer
            yield return new WaitForSeconds(flashInterval);
        }
    }
}
