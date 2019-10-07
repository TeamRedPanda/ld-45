using UnityEngine;

class ActorEmote : MonoBehaviour
{
    public void ShowDeathEmote()
    {
        DamagePopupController.Instance.ShowDeath(this.transform.position);
    }
}
