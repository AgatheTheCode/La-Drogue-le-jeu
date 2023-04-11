using UnityEngine;

public class LightOff : MonoBehaviour
{
    public Light lamp;
    public bool isOn = false;

    private void Start()
    {
        lamp.enabled = isOn;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Light lamp"))
        {
            isOn = !isOn;
            lamp.enabled = isOn;
        }
    }
}
