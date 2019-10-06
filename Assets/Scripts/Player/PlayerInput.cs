using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActorMovement))]
[RequireComponent(typeof(ActorWeapon))]
public class PlayerInput : MonoBehaviour
{
    ActorMovement m_ActorMovement;
    ActorWeapon m_ActorWeapon;
    Transform m_MainCamera;

    void Awake()
    {
        m_ActorMovement = GetComponent<ActorMovement>();
        m_ActorWeapon = GetComponent<ActorWeapon>();
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

        if (Input.GetButtonDown("Fire1")) {
            m_ActorWeapon.Attack();
        }
    }
}
