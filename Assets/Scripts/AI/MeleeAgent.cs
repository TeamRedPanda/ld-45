using UnityEngine;

[CreateAssetMenu(menuName = "Gladiator/AI/Melee")]
public class MeleeAgent : Agent
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
