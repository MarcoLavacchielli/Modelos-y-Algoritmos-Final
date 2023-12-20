using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType1 : Enemy
{
    protected override void InitializeStats()
    {
        base.InitializeStats();
        health = 2;
        damage = 1;
        speed = 5f;
    }
}