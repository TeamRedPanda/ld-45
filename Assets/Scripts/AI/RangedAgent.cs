using UnityEngine;

[CreateAssetMenu(menuName = "Gladiator/AI/Ranged")]
public class RangedAgent : Agent
{
    public override void Process(ActorAI actorAI)
    {
        if (actorAI.PlayerDistance <= AttackDistance) {
            actorAI.ActorMovement.LookAt(actorAI.PlayerDirection);
            actorAI.ActorMovement.StopMovement();
            TimeUntilNextAttack -= Time.deltaTime;
            if (actorAI.CanAttack && TimeUntilNextAttack <= 0f) {
                actorAI.ActorWeapon.Attack();
                actorAI.CanAttack = false;
                TimeUntilNextAttack = AttackRate;
            }
        } else {
            actorAI.ActorMovement.Move(actorAI.PlayerDirection, true);
        }
    }
}