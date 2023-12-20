using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType2 : Enemy
{
    protected override void InitializeStats()
    {
        base.InitializeStats();
        health = 3;
        damage = 2;
        //speed = 5f;
    }
}
