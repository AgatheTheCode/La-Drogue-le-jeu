using UnityEngine;

public class ChangeMaterialOnHit : MonoBehaviour
{
    public float raycastDistance = 100f;
    public LayerMask targetMask;
    public Material newMaterial;

    private Camera playerCamera;

    private void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 rayOrigin = playerCamera.transform.position;
            Vector3 rayDirection = playerCamera.transform.forward;

            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo, raycastDistance, targetMask))
            {
                Debug.Log("Objet touché : " + hitInfo.collider.name);

                Renderer renderer = hitInfo.collider.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = newMaterial;
                }
            }
        }
    }
}
