using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallDirection
{
    Forward, Backward
}
public class Ball : MonoBehaviour
{
    [SerializeField] BallDirection ballDirection;
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
        if (ballDirection == BallDirection.Forward) rb.AddForce(Vector3.forward * Speed * Time.deltaTime);
        if (ballDirection == BallDirection.Backward) rb.AddForce(Vector3.back * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pin"))
        {
            Time.timeScale = 0.5f;
            isgamelose = true;
            Debug.Log("Collision Enter");
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Pin"))
        {
            Time.timeScale = 1;
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
