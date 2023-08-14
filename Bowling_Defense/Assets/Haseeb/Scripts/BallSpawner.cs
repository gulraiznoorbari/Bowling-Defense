using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour
{
    [Tooltip("Instantiate Next Ball")]
    [SerializeField] float Time;
    [SerializeField] float XPos;
    [SerializeField] float YPos;
    [SerializeField] float ZPos;
    [SerializeField] int totalball;
    //private float divisor;
    [SerializeField] int currentball;
    private Vector3 SpawningPosition;
    [SerializeField] Transform SetParent;
    [SerializeField] Transform[] BallPrefab;
    [SerializeField] TextMeshProUGUI BallCounter;
    //[SerializeField] Image LevelProgress;
    // public int TotalBall() => totalball;
    // public int CurrentBall() => currentball;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Ball());
        //divisor = totalball;
        //currentball = 1;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Random.Range(-XPos, XPos);
        SpawningPosition = new Vector3(pos, YPos, ZPos);
        BallCounter.text = currentball.ToString() + "/" + totalball.ToString();
        //LevelProgress.fillAmount = currentball/divisor;
    }
    IEnumerator Ball()
    {
        for (currentball = 1; currentball <= totalball; currentball++)
        {
            //currentball++;
            int index = Random.Range(0,BallPrefab.Length);
            Instantiate(BallPrefab[index], transform.position + SpawningPosition, transform.rotation, SetParent);
            yield return new WaitForSeconds(Random.Range(1, Time));
        }
    }
}
