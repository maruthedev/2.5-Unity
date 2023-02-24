using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int damage;
    public abstract void OnTriggerEnter2D(Collider2D other);
}
