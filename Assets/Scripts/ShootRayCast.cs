using UnityEngine;
using UnityEngine.UI;

public class ShootRayCast : MonoBehaviour
{
    public float raycastDistance = 100f;
    public float sphereCastRadius = 0.1f;
    public LayerMask targetMask;

    public Image aimPoint;

    private Camera playerCamera;

    public void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();

        aimPoint = new GameObject("Aim Point").AddComponent<Image>();

        aimPoint.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        aimPoint.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        aimPoint.rectTransform.pivot = new Vector2(0.5f, 0.5f);

        aimPoint.rectTransform.sizeDelta = new Vector2(20f, 20f);

        aimPoint.transform.SetParent(playerCamera.transform);
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 rayOrigin = playerCamera.transform.position;
            Vector3 rayDirection = playerCamera.transform.forward;

            RaycastHit hitInfo;
            if (Physics.SphereCast(rayOrigin, sphereCastRadius, rayDirection, out hitInfo, raycastDistance, targetMask))
            {
                Debug.Log("Objet touché : " + hitInfo.collider.name);

                Renderer renderer = hitInfo.collider.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = Color.red;
                }
                //si l'objet a pour tag "Switch"
                if (hitInfo.collider.CompareTag("switch"))
                {
                    //on récupère le script Switch
                    Switch switchScript = hitInfo.collider.GetComponent<Switch>();
                    //on active/désactive l'objet
                    switchScript.isActivated = !switchScript.isActivated;
                    switchScript.SetSwitchColor();
                    switchScript.objectToActivate.SetActive(switchScript.isActivated);
                }
            }
        }

        aimPoint.rectTransform.position = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
    }
}
