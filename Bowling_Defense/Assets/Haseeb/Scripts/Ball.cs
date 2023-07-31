using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance;
    Rigidbody rb;
    [SerializeField] private float Speed;
    [SerializeField] private float speed;
    [SerializeField] private float Health;
    [SerializeField] private Vector3 Scale;
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        rb.AddForce(Vector3.forward * Speed);
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Ball Health : " + Health);
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Barriers"))
        {
            Speed = Speed - speed * Time.deltaTime;
            //transform.localScale = Vector3.Lerp(transform.localScale, Scale, Time.deltaTime);
        }
    }

    public void health()
    {
        Health -= Time.deltaTime;
        transform.localScale = transform.localScale - Scale * Time.deltaTime;
    }
}
