using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToLoad; // Le nom de la scène à charger

    // Méthode appelée lorsque le joueur clique sur l'objet avec le bouton gauche de la souris
    private void OnMouseDown()
    {
        RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.collider.CompareTag("porte2")) // Vérifie si l'objet a le tag "porte"
        {
            SceneManager.LoadScene(sceneToLoad); // Charge la scène spécifiée
        }
            }
    }

    
}