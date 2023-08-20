using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoMovementController : MonoBehaviour
{

    [SerializeField] float TornadoSpeed;
    [SerializeField] List<Transform> Waypoints = new List<Transform>();
    void Start()
    {
        GameObject[] waypoint;
        waypoint = GameObject.FindGameObjectsWithTag("Waypoints");
        foreach (GameObject points in waypoint)
        {
            Waypoints.Add(points.GetComponent<Transform>());
        }
        StartCoroutine(TornadoMovement());
    }
    void Update()
    {

    }


    IEnumerator TornadoMovement()
    {
        foreach (Transform waypoint in Waypoints)
        {
            Vector3 startposition = transform.position;
            Vector3 endposition = waypoint.position;
            float travelpercent = 0f;

            while (travelpercent < 1f)
            {
                travelpercent += Time.deltaTime * TornadoSpeed;
                transform.position = Vector3.Lerp(startposition, endposition, travelpercent);
                yield return new WaitForEndOfFrame();

            }
        }
    }
}
