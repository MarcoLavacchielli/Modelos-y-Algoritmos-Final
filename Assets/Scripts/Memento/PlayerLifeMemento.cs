using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeMemento : MonoBehaviour
{
    public int Life { get; private set; }

    public PlayerLifeMemento(int life)
    {
        Life = life;
    }
}
