using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileMovement : MonoBehaviour
{
    public float Speed;

    private Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.velocity = transform.rotation * new Vector3(0, 0, Speed);
    }
}
