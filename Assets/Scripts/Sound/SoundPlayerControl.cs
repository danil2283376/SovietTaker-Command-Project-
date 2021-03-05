using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayerControl : MonoBehaviour
{
    public AudioSource playerMove;
    public AudioSource playerDeath;
    public AudioSource playerKickEnemy;
    public AudioSource playerKickStone;
    public AudioSource playerSteppedOnMine;

    /// <summary>
    /// Звук ходьбы
    /// </summary>
    public void PlayerMoveSound() // звук ходьбы
    {
        playerMove.pitch = Random.Range(0.9f, 1.1f);
        playerMove.Play();
    }

    /// <summary>
    /// Звук смерти
    /// </summary>
    public void PlayerDeathSound() // звук смерти
    {
        playerDeath.Play();
    }

    /// <summary>
    /// Звук пинка врага
    /// </summary>
    public void PlayerKickEnemy() // звук пинка врага
    {
        playerKickEnemy.Play();
    }

    /// <summary>
    /// Звук пинка камня
    /// </summary>
    public void PlayerKickStone() // звук пинка камня
    {
        playerKickStone.Play();
    }

    public void PlayerSteppedOnMineSound()
    {
        playerSteppedOnMine.Play();
    }
}
