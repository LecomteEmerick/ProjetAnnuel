﻿using UnityEngine;
using UnityEngine.Events;

public class OnHitMobScript : MonoBehaviour
{

    [SerializeField]
    private byte _layer;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private EntityStatisticScript stats;
    [SerializeField]
    private UnitManager unitManager;
    [SerializeField]
    private HitMobEvent eventToFire;

    void Start()
    {
        Debug.Log("Hello On collision");
        if (eventToFire == null)
            Debug.Log("Aucun event renseigné.");
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision " + collision.gameObject.layer + " == " + _layer + " - Damage : " + (int)animator.GetFloat("DamageCoeff") * stats.Damage);
        if (collision.gameObject.layer == _layer)
            if (eventToFire != null)
                eventToFire.Invoke(collision.collider, (int) animator.GetFloat("DamageCoeff") * stats.Damage);
    }
}
