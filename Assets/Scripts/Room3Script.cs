// using UnityEngine;
// using UnityEngine.SceneManagement;
// //using UnityEngine.Rendering.PostProcessing;
// using System.Collections;

// public class Room3Script : MonoBehaviour
// {
//     public float shakeDuration = 0.5f; // La durée du tremblement
//     public float shakeAmount = 0.1f; // L'intensité du tremblement
//     public float decreaseFactor = 1.0f; // La vitesse à laquelle le tremblement diminue
//     public Camera playerCamera;
//     private Vector3 originalPosition; // La position de la caméra avant le tremblement
//     private Camera mainCamera; // Ajout de la variable mainCamera de type Camera

//     private bool isTrembling = false; // Ajout d'un indicateur pour savoir si le tremblement est en cours

//     void Awake()
//     {
//         // Récupère la caméra principale de la scène
//         mainCamera = playerCamera.GetComponent<Camera>();
//     }

//     void Start()
//     {
//         GameObject[] Room3 = GameObject.FindGameObjectsWithTag("Room3");

//         foreach (GameObject fiole in Room3)
//         {
//             if (fiole.CompareTag("Fiole1"))
//             {
//                  // Ajoute un écouteur d'événements pour détecter le clic sur la fiole1
//                 fiole.GetComponent<Collider>().gameObject.AddComponent<Fiole1ClickHandler>();
//                 Debug.Log("fiole1");
//             }

//             if (fiole.CompareTag("Fiole2"))
//             {
//                 // Ajout d'un écouteur d'événements pour détecter le clic sur la fiole2
//                 fiole.GetComponent<Collider>().gameObject.AddComponent<Fiole2ClickHandler>();
//                 Debug.Log("fiole2");

//             }
//         }
//     }

//     // Classe interne pour gérer le clic sur la fiole2
//     private class Fiole2ClickHandler : MonoBehaviour
//     {
//         private void OnMouseDown()
//         {
//             // Vérifie que le tremblement n'est pas déjà en cours
//             if (!GameObject.FindObjectOfType<Room3Script>().isTrembling)
//             {
//                 Debug.Log("tremblement");
//                 // Démarre la coroutine de tremblement
//                 GameObject.FindObjectOfType<Room3Script>().StartCoroutine(GameObject.FindObjectOfType<Room3Script>().ShakeCamera());
//             }
//         }
//     }

//     private System.Collections.IEnumerator ShakeCamera()
//     {
//         isTrembling = true; // Indique que le tremblement est en cours
//         originalPosition = mainCamera.transform.localPosition;
//         float shakeTimer = shakeDuration;

//         while (shakeTimer > 0)
//         {
//             // Calcule la position de la caméra avec le tremblement
//             Vector3 randomPosition = originalPosition + Random.insideUnitSphere * shakeAmount;
//             mainCamera.transform.localPosition = randomPosition;

//             // Diminue le tremblement progressivement
//             shakeTimer -= Time.deltaTime * decreaseFactor;

//             yield return null;
//         }

//         // Remet la caméra à sa position d'origine
//         mainCamera.transform.localPosition = originalPosition;

//         isTrembling = false; // Indique que le tremblement est terminé
//     }

//     // Classe interne pour gérer le clic sur la fiole1
// private class Fiole1ClickHandler : MonoBehaviour
// {
//     private void OnMouseDown()
//     {
//         // Applique l'effet de flou
//         GameObject.FindObjectOfType<Room3Script>().StartCoroutine(GameObject.FindObjectOfType<Room3Script>().BlurEffect());
//     }
// }

// // Coroutine pour appliquer l'effet de flou
// private IEnumerator BlurEffect()
// {
//     // Récupère le post-processing volume de la caméra
//     PostProcessVolume postProcessVolume = playerCamera.GetComponent<PostProcessVolume>();

//     // Crée une instance du profil post-processing
//     PostProcessProfile profile = postProcessVolume.sharedProfile;
//     PostProcessProfile blurredProfile = Instantiate(profile);

//     // Récupère le composant de flou du profil post-processing
//     DepthOfField depthOfField;
//     if (!blurredProfile.TryGetSettings(out depthOfField))
//     {
//         depthOfField = blurredProfile.AddSettings<DepthOfField>();
//     }

//     // Applique le flou
//     depthOfField.active = true;
//     depthOfField.focusDistance.Override(0.1f);
//     depthOfField.aperture.Override(0.1f);
//     depthOfField.focalLength.Override(50f);
//     depthOfField.kernelSize.Override(KernelSize.Large);

//     // Applique le profil post-processing modifié
//     postProcessVolume.sharedProfile = blurredProfile;

//     // Attend quelques secondes
//     yield return new WaitForSeconds(2f);

//     // Rétablit le profil post-processing d'origine
//     postProcessVolume.sharedProfile = profile;
// }

// }
