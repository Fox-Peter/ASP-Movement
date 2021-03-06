using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    const float G = 6.67408f;

    [SerializeField] private float m_forceMultiplier;
    [SerializeField] private Rigidbody m_rb;

    public Rigidbody RigidBody
    {
        get { return m_rb; }
    }

    public static List<Attractor> AttractorList;

    private void FixedUpdate()
    {
        foreach(Attractor attractor in AttractorList)
        {
            Attract(attractor);
        }
    }

    private void OnEnable()
    {
        if(AttractorList == null)
        {
            AttractorList = new List<Attractor>();
        }

        m_rb.mass = transform.localScale.magnitude;

        AttractorList.Add(this);
    }

    private void OnDisable()
    {
        AttractorList.Remove(this);
    }

    void Attract(Attractor obj)
    {
        Rigidbody otherRB = obj.RigidBody;

        Vector3 direction = m_rb.position - otherRB.position;
        float distance = direction.magnitude;

        if (distance == 0f)
            return;

        float forceMag = G * m_forceMultiplier * (m_rb.mass * otherRB.mass) / Mathf.Pow(distance, 2f);
        Vector3 forceVec = direction.normalized * forceMag;

        otherRB.AddForce(forceVec);
    }
}
