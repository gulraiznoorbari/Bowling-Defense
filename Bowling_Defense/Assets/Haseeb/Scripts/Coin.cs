using System.Collections;
using System.Collections.Generic;
using AssetKits.ParticleImage;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] ParticleImage CoinsEffect;
    [SerializeField] float time;
    [SerializeField] float CurrentTime;
    [SerializeField] int coins;
    
    Bank bank;
    // Start is called before the first frame update
    private void Start()
    {
        bank = FindObjectOfType<Bank>();
        CurrentTime = 0;
        CoinsEffect.Stop();
    }
    private void Update()
    {
        CurrentTime += Time.deltaTime;
        if(CurrentTime >= time)
        {
            CoinsEffect.Play();
        }
        if(CurrentTime >= time + 0.5f)
        {
            CoinsEffect.Stop(false);
            CurrentTime = 0;
        }
        if(CoinsEffect.isPlaying)
        {
            int Cash = 0;
            Cash += coins;
            bank.CashDeposite(Cash);
        }
    }
}
