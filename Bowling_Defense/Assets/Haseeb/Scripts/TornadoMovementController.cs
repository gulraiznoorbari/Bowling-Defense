using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoMovementController : MonoBehaviour
{

    [SerializeField] float TornadoSpeed;
    [SerializeField] List<Transform> Waypoints = new List<Transform>();
    // [SerializeField] List<Ball> Balls = new List<Ball>();

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, Waypoints[0].position, Time.deltaTime * TornadoSpeed);
    }


    IEnumerator TornadoMovement()
    {
        foreach (Transform waypoint in Waypoints)
        {
            Vector3 startposition = transform.position;
            Vector3 endposition = waypoint.position;
            float travelpercent = 0f;

            // transform.LookAt(endposition);

            while (travelpercent < 1f)
            {
                travelpercent += Time.deltaTime * TornadoSpeed;
                transform.position = Vector3.Lerp(startposition, endposition, travelpercent);
                yield return new WaitForEndOfFrame();

            }
        }
    }
}
