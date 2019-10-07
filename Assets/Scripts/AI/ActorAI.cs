using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorAI : MonoBehaviour
{
    public ActorMovement ActorMovement;
    public ActorWeapon ActorWeapon;

    public GameObject Player;
    public Agent Agent;

    public Vector3 PlayerDirection { get; private set; }
    public float PlayerDistance { get; private set; }

    public bool CanAttack = true;

    public void OnAttackLanded()
    {
        CanAttack = true;
    }

    // Start is called before the first frame update
    void Awake()
    {
        ActorMovement = GetComponent<ActorMovement>();
        ActorWeapon = GetComponent<ActorWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDirection = Player.transform.position - this.transform.position;
        PlayerDistance = PlayerDirection.magnitude;

        Debug.Log($"{PlayerDistance}");

        Agent.Process(this);
    }
}