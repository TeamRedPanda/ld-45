using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActorMovement))]
public class PlayerInput : MonoBehaviour
{
    ActorMovement m_ActorMovement;

    void Awake()
    {
        m_ActorMovement = GetComponent<ActorMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        var direction = new Vector3(horizontal, 0f, vertical);
        m_ActorMovement.Move(direction, true);
    }
}
