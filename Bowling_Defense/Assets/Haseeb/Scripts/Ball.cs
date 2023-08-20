using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float Speed;
    [SerializeField] bool isgamelose;
    public bool GameLose() => isgamelose;
    [SerializeField] Vector3 BallDestroyPosition;
    [SerializeField] Vector3 BallPosition;
    private void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        BallPosition = transform.position;
        rb.AddForce(Vector3.forward * Speed * Time.deltaTime);
        if (transform.position.z >= BallDestroyPosition.z)
        {
            isgamelose = true;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pin"))
        {
            Debug.Log("Collision Enter");
            isgamelose = true;
        }
    }
}
