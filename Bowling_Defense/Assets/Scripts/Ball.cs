using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    private SphereCollider sphereCollider;

    [SerializeField] private float Speed;
    [SerializeField] private bool _isGameLost;
    public bool GameLose() => _isGameLost;

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
            _isGameLost = true;
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
