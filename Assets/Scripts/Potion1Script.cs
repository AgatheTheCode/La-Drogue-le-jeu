using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
public Camera playerCamera;

   
public class Potion1Script : MonoBehaviour
{
    public float blurAmount = 0.5f; // la quantité de flou à appliquer

    void OnMouseDown()
    {
    
            // Récupère la caméra principale de la scène
            Camera mainCamera = playerCamera.GetComponent<Camera>();

            // Vérifie si un composant post-processus est attaché à la caméra
            PostProcessVolume volume = mainCamera.GetComponent<PostProcessVolume>();
            if (volume == null)
            {
                Debug.LogError("No post-processing volume found on main camera");
                return;
            }

            // Récupère le profil post-processus du volume
            PostProcessProfile profile = volume.profile;

            // Vérifie si l'effet de flou existe déjà dans le profil
            DepthOfField dof;
            if (!profile.TryGetSettings(out dof))
            {
                // Ajoute l'effet de flou au profil si il n'existe pas déjà
                dof = profile.AddSettings<DepthOfField>();
            }

            // Active l'effet de flou et définit la quantité de flou à appliquer
            dof.enabled.value = true;
            dof.aperture.value = blurAmount;

            // Charge la scène suivante
            SceneManager.LoadScene("Salle4");
        
    }
}  
