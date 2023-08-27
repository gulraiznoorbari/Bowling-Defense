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
    [SerializeField] int currentball;
    private Vector3 SpawningPosition;
    [SerializeField] Transform SetParent;
    [SerializeField] Ball[] BallPrefab;
    [SerializeField] TextMeshProUGUI BallCounter;
    //[SerializeField] Ball[] balls;
    [SerializeField] public List<Ball> RemainingBalls = new List<Ball>();
    [SerializeField] int remainingballint;
    public int TotalBall() => totalball;
    public int CurrentBall() => currentball;
    public int RemainingBallint() => remainingballint;
    [SerializeField] UIManager uIController;

    private void Start()
    {
        uIController = FindObjectOfType<UIManager>();
        StartCoroutine(Ball());
    }

    private void Update()
    {
        remainingballint = RemainingBalls.Count;
        bool win = uIController.Win();
        bool lose = uIController.lose();
        if (win)
        {
            Destroy(this.gameObject);
        }
        if (lose)
        {
            Destroy(this.gameObject);
        }
        var pos = Random.Range(-XPos, XPos);
        SpawningPosition = new Vector3(pos, YPos, ZPos);
        BallCounter.text = "Wave " + currentball.ToString() + "/" + totalball.ToString();
    }

    IEnumerator Ball()
    {
        for (currentball = 1; currentball < totalball; currentball++)
        {
            int index = Random.Range(0, BallPrefab.Length);
            Instantiate(BallPrefab[index], transform.position + SpawningPosition, transform.rotation, SetParent);
            Ball balls = FindObjectOfType<Ball>();
            RemainingBalls.Add(balls);
            yield return new WaitForSeconds(Time);
        }
    }
}
