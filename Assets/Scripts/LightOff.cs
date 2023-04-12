using UnityEngine;

public class LightOff : MonoBehaviour
{
    public Light lamp;
    public bool isOn = false;

    private void Start()
    {
        lamp.enabled = isOn;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                Debug.DrawRay(Camera.main.transform.position, hit.point - Camera.main.transform.position, Color.red, 1f);
                if (hit.collider.CompareTag("Bouton"))
                {
                    isOn = !isOn;
                    lamp.enabled = isOn;
                }
            }
        }
    }
}
