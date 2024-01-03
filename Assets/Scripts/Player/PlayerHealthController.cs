using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public bool IsInvincible = false;

    private InvincibilityController _invincibilityController;

    public void TakeDamage()
    {
        _invincibilityController.InvincibilityCoroutine();
    }
}
