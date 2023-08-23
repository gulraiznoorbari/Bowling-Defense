using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particlecollision : MonoBehaviour
{
    
    // [SerializeField] int Amount;
    // [SerializeField] GameObject Coin;
    [SerializeField] GameObject Effect;
    // [SerializeField] float CoinDestroyTime;
    [SerializeField] float EffectDestroyTime;
    private BallSpawner ballSpawner;
    // Bank bank;
    // Start is called before the first frame update
    void Start()
    {
        ballSpawner = FindObjectOfType<BallSpawner>();
        // bank = FindObjectOfType<Bank>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnParticleCollision(GameObject other)
    {
        // bank.CashDeposite(Amount);
        Destroy(Instantiate(Effect, transform.position, Quaternion.identity), EffectDestroyTime);
        Destroy(gameObject);
        // Destroy(Instantiate(Coin, transform.position, Coin.transform.rotation), CoinDestroyTime);
    }
}
