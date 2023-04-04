using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light pointLight;
    public Color activeColor = Color.green;
    public Color inactiveColor = Color.red;
    public float maxDistance = 5f;

    private bool isLightOn = true;

    void Start()
    {
        pointLight.color = activeColor;
    }

    void Update()
    {
        // Vérifier si le joueur tire un rayon vers l'interrupteur et si le rayon le touche
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit: " + hit.collider.gameObject.name);
                Debug.Log("Distance: " + hit.distance);
                if ((hit.distance < maxDistance))
                {
                    if (hit.distance < maxDistance)
                    {
                        if (hit.collider.gameObject == gameObject && !isLightOn)
                        {
                            // Allumer la lumière
                            TurnOnLight();
                        }
                        else if (hit.collider.gameObject == gameObject && isLightOn)
                        {
                            // Éteindre la lumière
                            TurnOffLight();
                        }
                    }
                } else
                {
                    Debug.Log("Trop loin");
                }
            }
        }
    }

    void ToggleLight()
    {
        if (isLightOn)
        {
            // Éteindre la lumière
            TurnOffLight();
        }
        else
        {
            // Allumer la lumière
            TurnOnLight();
        }
    }

    void TurnOnLight()
    {
        pointLight.color = activeColor;
        isLightOn = true;
    }

    void TurnOffLight()
    {
        pointLight.color = inactiveColor;
        isLightOn = false;
    }
}
