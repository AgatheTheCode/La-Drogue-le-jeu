using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light pointLight;
    public Color activeColor = Color.green;
    public Color inactiveColor = Color.red;

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
                if ((hit.collider.gameObject == gameObject) || (isLightOn = false))
                {
                    // Allumer ou éteindre la lumière
                    ToggleLight();
                }
                else
                {
                    // Éteindre la lumière
                    TurnOffLight();
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Vérifier si le joueur entre dans la zone de déclenchement et regarde l'interrupteur
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(transform.forward, direction);

            if (angle < 45)
            {
                // Allumer la lumière
                TurnOnLight();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Vérifier si le joueur quitte la zone de déclenchement
        if (other.gameObject.CompareTag("Player"))
        {
            // Éteindre la lumière
            TurnOffLight();
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
