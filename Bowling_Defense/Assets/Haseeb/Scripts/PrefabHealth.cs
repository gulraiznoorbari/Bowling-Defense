using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabHealth : MonoBehaviour
{
    [SerializeField] private float Health;
    [SerializeField] private Ball ball;

    private void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }

        Debug.Log("Barrier Health : " + Health);
    }

    private void OnCollisionEnter(Collision other)
    {
        ball = FindObjectOfType<Ball>();
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ball.health();
            Health -= Time.deltaTime;
        }
    }
}
