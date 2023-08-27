using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static partial class Events
{
    public static event Action<Vector3> OnBallCollided;
    public static void BallColided(Vector3 position) => OnBallCollided?.Invoke(position);
}

public class Particlecollision : MonoBehaviour
{
    [SerializeField] BallSpawner ballSpawner;
    [SerializeField] GameObject Effect;
    [SerializeField] float EffectDestroyTime;
    [SerializeField] GameObject[] NonDestroyEffect;

    private void Start()
    {
        ballSpawner = FindObjectOfType<BallSpawner>();
    }
    private void OnParticleCollision(GameObject other)
    {
        ballSpawner.RemainingBalls.Remove(this.gameObject.GetComponent<Ball>());
        Events.BallColided(transform.position);
        int range = Random.Range(0, NonDestroyEffect.Length);
        Instantiate(NonDestroyEffect[range], transform.position, Quaternion.identity);
        Destroy(Instantiate(Effect, transform.position, Quaternion.identity), EffectDestroyTime);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "End")
        {
            ballSpawner.RemainingBalls.Remove(this.gameObject.GetComponent<Ball>());
            Destroy(gameObject);
        }
    }
}
