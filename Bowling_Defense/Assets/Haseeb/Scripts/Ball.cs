using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance;
    Rigidbody rb;
    [SerializeField] float Speed;
    [SerializeField] float speed;
    [SerializeField] float Health;
    [SerializeField] Vector3 Scale;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.forward * Speed);
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Ball Health : " + Health);
    }
    void OnCollisionStay(Collision other)
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
