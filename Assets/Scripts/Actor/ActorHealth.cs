using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActorHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
            currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if ( currentHealth <= 0 ) {
            Destroy( gameObject );
        }
    }

    public void ApplyDamage( int damage )
    {
        currentHealth -= damage;
    }
}
