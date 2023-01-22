using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// Класс-заглушка, пока нет анимации смерти.
// Сам аниматор находится в дочернем объекте.
public class EnemyAnimatable : MonoBehaviour, IAnimatable
{
    public UnityEvent DiedAnimationPlayedEvent => _diedAnimationPlayedEvent;

    private UnityEvent _diedAnimationPlayedEvent;

    public void PlayDeathAnimation()
    {
        _diedAnimationPlayedEvent?.Invoke();
    }
}
