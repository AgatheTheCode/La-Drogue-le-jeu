using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject objectToActivate;
    public Color activeColor = Color.green;
    public Color inactiveColor = Color.white;
    public float raycastDistance = 100f;
    public LayerMask raycastLayerMask = -1;
    public Color raycastColor = Color.blue;

public bool isActivated { get; set; } = false;
    public void Start()
    {
        //récupération des objets qui ont le tag SWITCHED
        objectToActivate = GameObject.FindGameObjectWithTag("switched");
        SetSwitchColor();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))    {
            Debug.Log('E');
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, raycastLayerMask))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    isActivated = !isActivated;
                    SetSwitchColor();
                    objectToActivate.SetActive(isActivated);
                }
            }
        }
    }

    public void SetSwitchColor()
    {
        Renderer switchRenderer = GetComponent<Renderer>();
        switchRenderer.material.color = isActivated ? activeColor : inactiveColor;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = raycastColor;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * raycastDistance);
            }
}
