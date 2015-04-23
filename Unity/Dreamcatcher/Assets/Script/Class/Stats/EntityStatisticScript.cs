﻿using UnityEngine;
using System;
using System.Collections;

public abstract class EntityStatisticScript : MonoBehaviour {

    [SerializeField]
    protected int MaxHealth;
    [SerializeField]
    protected int CurrentHealth;
    [SerializeField]
    protected int Damage;

    public abstract void TakeDamage(int damage);

    public void TemporaryIncreaseDamage(int value, int secondes)
    {
        this.IncreaseDamage(value);
        StartCoroutine(executeAfterTime(DecreaseDamage, secondes, value));
    }

    public void IncreaseDamage(int value)
    {
        this.Damage += value;
    }

    public void DecreaseDamage(int value)
    {
        this.Damage -= value;
        if(this.Damage < 1)
        {
            this.Damage = 0;
        }
    }

    private IEnumerator executeAfterTime(Action<int> function, int secondes, int value)
    {
        yield return new WaitForSeconds(secondes);
        function(value);
    }

    public int getDamage()
    {
        return Damage;
    }
}
