using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    private bool IsPlaying;
    private float EffectDuration;
    [SerializeField] float Reset;
    [SerializeField] float EffectTime;
    [SerializeField] GameObject[] Effect;
    // Start is called before the first frame update
    void Start()
    {
        EffectDuration = 0f;
        foreach (GameObject effect in Effect)
        {
            effect.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Particle();
        Debug.Log(EffectTime);
        if (!IsPlaying)
        {
            EffectTime -= Time.deltaTime;
            if (EffectTime <= EffectDuration)
            {
                foreach (GameObject effect in Effect)
                {
                    effect.SetActive(false);
                }
            }
        }
    }
    public void PointerDown(int item)
    {
        IsPlaying = true;
        if (IsPlaying)
        {
            EffectTime = Reset;
            Effect[item].SetActive(true);
        }
    }
    public void PointerUp(int item)
    {
        IsPlaying = false;
    }
    // public void Particle()
    // {
    //     if (IsPlaying)
    //     {
    //         EffectTime = Reset;
    //         Effect.SetActive(true);
    //     }

    //     if (!IsPlaying)
    //     {
    //         if (EffectTime <= EffectDuration)
    //         {
    //             Effect.SetActive(false);
    //         }
    //     }
    // }

}
