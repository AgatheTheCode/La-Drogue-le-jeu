using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XboxMapping : MonoBehaviour
{
    private Rigidbody rb;
    private Camera cam;
    private bool canJump = true;

    // Vitesse de mouvement du joueur
    public float speed = 5.0f;
    public float sprintSpeed = 10.0f;

    // La hauteur maximale à laquelle le joueur peut sauter
    public float jumpHeight = 2.0f;

    //distance du bord
    public float edgeDistance = 1.0f;

    // Le layerMask des objets solides
    public LayerMask solidMask;

    void Start()
    {
        //récupérer la rigidbody du joueur
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mouvement en avant et en arrière
        float verticalAxis = Input.GetAxis("Vertical");
        if (verticalAxis > 0)
        {
            Vector3 forward = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z).normalized;
            transform.position += forward * Time.deltaTime * speed * verticalAxis;
        }
        else if (verticalAxis < 0)
        {
            Vector3 forward = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z).normalized;
            transform.position -= forward * Time.deltaTime * speed * Mathf.Abs(verticalAxis);
        }

        // Mouvement latéral
        float horizontalAxis = Input.GetAxis("Horizontal");
        if (horizontalAxis < 0)
        {
            transform.position -= cam.transform.right * Time.deltaTime * speed * Mathf.Abs(horizontalAxis);
        }
        else if (horizontalAxis > 0)
        {
            transform.position += cam.transform.right * Time.deltaTime * speed * horizontalAxis;
        }

        // Saut
        if (Input.GetButtonDown("Jump") && canJump)
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2.0f * Physics.gravity.y), ForceMode.VelocityChange);
            canJump = false;
            StartCoroutine(ResetJump());
        }

        // Sprint
        float sprintAxis = Input.GetAxis("RT");
        if (sprintAxis > 0)
        {
            speed = sprintSpeed * sprintAxis;
        }
        else
        {
            speed = 5.0f;
        }
    }

    IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(2.5f);
        canJump = true;
    }
}
