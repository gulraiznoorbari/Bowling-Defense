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
    [SerializeField] Transform[] BallPrefab;
    [SerializeField] TextMeshProUGUI BallCounter;
    public int TotalBall() => totalball;
    public int CurrentBall() => currentball;
    [SerializeField] UIManager UiManager;
    void Start()
    {
        UiManager = FindObjectOfType<UIManager>();
        StartCoroutine(Ball());
    }
    void Update()
    {
        bool win = UiManager.Win();
        bool lose = UiManager.lose();
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
        
        BallCounter.text = currentball.ToString() + "/" + totalball.ToString();
    }
    IEnumerator Ball()
    {
        for (currentball = 1; currentball < totalball; currentball++)
        {
            int index = Random.Range(0, BallPrefab.Length);
            Instantiate(BallPrefab[index], transform.position + SpawningPosition, transform.rotation, SetParent);
            yield return new WaitForSeconds(Time);
        }
    }
}
