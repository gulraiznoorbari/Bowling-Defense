using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float Speed;
    [SerializeField] bool isgamelose;
    [SerializeField] SphereCollider sphereCollider;
    public bool GameLose() => isgamelose;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        rb.AddForce(Vector3.forward * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pin"))
        {
            isgamelose = true;
            Debug.Log("Collision Enter");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PinBoundry"))
        {
            sphereCollider.radius = 1;
        }
    }
}
