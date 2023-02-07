using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    public GameObject[] target = default;
    public float attackSpeed = default;
    public float attakRange = default;
    public float attackDamage = default;
    public float bulletSpeed = default;
    void Start()
    {

    }
    void Update()
    {

    }
    public abstract void Shoot();
    public abstract void Targeting();
}