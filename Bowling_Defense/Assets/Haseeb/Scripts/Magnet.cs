using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private float MagnetStrength;
    [SerializeField] private List<Rigidbody> IronBalls = new List<Rigidbody>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            IronBalls.Add(other.GetComponent<Rigidbody>());
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            foreach (Rigidbody ironball in IronBalls)
            {
                ironball.AddForce((transform.position - ironball.position) * MagnetStrength * Time.deltaTime);
            }
        }
    }
}
