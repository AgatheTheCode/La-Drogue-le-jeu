using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string Scene2; // Le nom de la scène 2 à charger
    public string Salle_3; // Le nom de la salle 3 à charger
    public string Scene4; // Le nom de la scène 4 à charger

    // Méthode appelée lorsque le joueur clique sur l'objet avec le bouton gauche de la souris
    private void OnMouseDown()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider.CompareTag("porte1")) // Vérifie si l'objet a le tag "porte"
            {
                SceneManager.LoadScene(Scene2); // Charge la scène 2
            }
            else if (hit.collider.CompareTag("porte2")) // Vérifie si l'objet a le tag "porte2"
            {
                SceneManager.LoadScene(Salle_3); // Charge la salle 3
            }
            else if (hit.collider.CompareTag("porte3")) // Vérifie si l'objet a le tag "porte3"
            {
                SceneManager.LoadScene(Scene4); // Charge la scène 4
            }
        }
    }
}