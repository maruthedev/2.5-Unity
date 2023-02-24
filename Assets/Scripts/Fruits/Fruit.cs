using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fruit : MonoBehaviour
{
    public int Score;
    public abstract void OnTriggerEnter2D(Collider2D other);
}
