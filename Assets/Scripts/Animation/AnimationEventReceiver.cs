using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventReceiver : MonoBehaviour
{
    [Header("Active phase")]
    public UnityEvent OnActivePhaseStart;
    public UnityEvent OnActivePhaseEnd;

    [Header("Movement status")]
    public UnityEvent OnAttackAnimationStart;
    public UnityEvent OnBackswingAnimationStart;

    public void ActivePhaseStart()
    {
        OnActivePhaseStart.Invoke();
    }

    public void ActivePhaseEnd()
    {
        OnActivePhaseEnd.Invoke();
    }

    public void AttackAnimationStarted()
    {
        OnAttackAnimationStart.Invoke();
    }

    public void BackswingAnimationStarted()
    {
        OnBackswingAnimationStart.Invoke();
    }
}
