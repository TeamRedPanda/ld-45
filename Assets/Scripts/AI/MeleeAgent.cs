using UnityEngine;

[CreateAssetMenu(menuName = "Gladiator/AI/Melee")]
public class MeleeAgent : Agent
{
    public override void Process(ActorAI actorAI)
    {
        if (actorAI.PlayerDistance <= AttackDistance) {
            actorAI.ActorMovement.LookAt(actorAI.PlayerDirection);
            if (actorAI.CanAttack) {
                actorAI.ActorWeapon.Attack();
                actorAI.CanAttack = false;
            }
        } else {
            actorAI.ActorMovement.Move(actorAI.PlayerDirection, true);
        }
    }
}
