using System;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public event Action Died;
    private bool _isDead = false;
    public bool IsDead => _isDead;
    public void Die()
    {
        _isDead = true;
        Died?.Invoke();
    }

    public void Restart()
    {
        _isDead = false;
    }
}
