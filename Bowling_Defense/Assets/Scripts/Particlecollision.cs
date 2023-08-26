using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    [SerializeField] GameObject Effect;
    [SerializeField] float EffectDestroyTime;
    [SerializeField] GameObject[] NonDestroyEffect;
    
    private void OnParticleCollision(GameObject other)
    {
        int range = Random.Range(0, NonDestroyEffect.Length);
        Instantiate(NonDestroyEffect[range], transform.position, Quaternion.identity);
        Destroy(Instantiate(Effect, transform.position, Quaternion.identity), EffectDestroyTime);
        Destroy(gameObject);
    }
}
