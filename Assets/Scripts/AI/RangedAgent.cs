using UnityEngine;

[CreateAssetMenu(menuName = "Gladiator/AI/Ranged")]
public class RangedAgent : Agent
{
    public override void Process(ActorAI actorAI)
    {
        if (actorAI.PlayerDistance <= AttackDistance) {
            actorAI.ActorMovement.LookAt(actorAI.PlayerDirection);
            actorAI.ActorWeapon.Attack();
        } else {
            actorAI.ActorMovement.Move(actorAI.PlayerDirection, true);
        }
    }
}