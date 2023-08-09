using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Tooltip("Instantiate Next Ball")]
    [SerializeField] float Time;
    [SerializeField] float XPos;
    [SerializeField] float YPos;
    [SerializeField] float ZPos;
    [SerializeField] int TotalBall;
    private Vector3 SpawningPosition;
    [SerializeField] Transform SetParent;
    [SerializeField] Transform[] BallPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Ball());
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Random.Range(-XPos, XPos);
        SpawningPosition = new Vector3(pos, YPos, ZPos);
    }
    IEnumerator Ball()
    {
        for (int i = 0; i <= TotalBall; i++)
        {
            i++;
            int index = Random.Range(0,BallPrefab.Length);
            Instantiate(BallPrefab[index], transform.position + SpawningPosition, transform.rotation, SetParent);
            yield return new WaitForSeconds(Random.Range(0, Time));
        }
    }
}
