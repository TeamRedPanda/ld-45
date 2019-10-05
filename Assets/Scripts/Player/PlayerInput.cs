using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActorMovement))]
public class PlayerInput : MonoBehaviour
{
    ActorMovement m_ActorMovement;
    Transform m_MainCamera;

    void Awake()
    {
        m_ActorMovement = GetComponent<ActorMovement>();
        m_MainCamera = FindObjectOfType<Camera>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        var direction = new Vector3(horizontal, 0f, vertical);
        var cameraRotation = Quaternion.Euler(0, m_MainCamera.rotation.eulerAngles.y, 0);
        direction = cameraRotation * direction;
        m_ActorMovement.Move(direction, true);
    }
}
