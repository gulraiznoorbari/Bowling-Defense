using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float Speed;
    [SerializeField] bool isgamelose;
    public bool GameLose() => isgamelose;
    private void Start()
    {

        rb = GetComponent<Rigidbody>();
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
}
