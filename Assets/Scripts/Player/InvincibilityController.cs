using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private PlayerHealthController _playerHealthController;
    private SpriteFlash _spriteflash;

    [SerializeField]
    private float invincibilityDuration;

    [SerializeField]
    private Color flashColor;

    [SerializeField]
    private int numberOfFlashes;

    // Start is called before the first frame update
    void Awake()
    {
        _playerHealthController = GetComponent<PlayerHealthController>();
        _spriteflash = GetComponent<SpriteFlash>();
    }

    public IEnumerator InvincibilityCoroutine()
    {
        _playerHealthController.IsInvincible = true;
        yield return _spriteflash.FlashCoroutine(invincibilityDuration, flashColor, numberOfFlashes);
        _playerHealthController.IsInvincible = false;
    }
}
