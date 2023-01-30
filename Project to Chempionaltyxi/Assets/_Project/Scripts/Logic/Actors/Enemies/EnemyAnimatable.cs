using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// Класс-заглушка, пока нет анимации смерти.
// Сам аниматор находится в дочернем объекте.
public class EnemyAnimatable : MonoBehaviour, IAnimatable
{
    [SerializeField] private Animator _animator;

    [Header("Настройки анимации")]
    [SerializeField] private float _diedAnimationTime;
    [SerializeField] private string _deathTriggerName;
    [SerializeField] private string _shootTriggerName;
    [SerializeField] private string _shootingStateTriggerName;

    private UnityEvent _diedAnimationPlayedEvent = new UnityEvent();

    public void SubscribeDeathEndAnimation(UnityAction deathAction) 
        => _diedAnimationPlayedEvent.AddListener(deathAction);

    public void UnSubscribeDeathEndAnimation(UnityAction deathAction)
        => _diedAnimationPlayedEvent.RemoveListener(deathAction);

    public void PlayDeathAnimation() 
        => StartCoroutine(DiedAnimationCoroutine());

    public void EnterShootingState() 
        => _animator.SetTrigger(_shootingStateTriggerName);

    public void ShootAnimation()
        => _animator.SetTrigger(_shootTriggerName);

    IEnumerator DiedAnimationCoroutine()
    {
        _animator.SetTrigger(_deathTriggerName);
        yield return new WaitForSeconds(_diedAnimationTime);

        _diedAnimationPlayedEvent?.Invoke();
    }
}
