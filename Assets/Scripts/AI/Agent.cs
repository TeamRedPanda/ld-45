using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Agent : ScriptableObject
{
    [SerializeField] protected float AttackDistance;

    public float AttackRate;
    [HideInInspector] public float TimeUntilNextAttack = 0;

    public abstract void Process(ActorAI actorAI);
}
