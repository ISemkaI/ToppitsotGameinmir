using System;
using UnityEngine.Events;

public interface IAnimatable
{
    void SubscribeDeathEndAnimation(UnityAction deathAction);
    void UnSubscribeDeathEndAnimation(UnityAction deathAction);

    void PlayDeathAnimation();

    void EnterShootingState();

    void ShootAnimation();
}