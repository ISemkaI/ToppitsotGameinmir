using UnityEngine.Events;

public interface IAnimatable
{
    UnityEvent DiedAnimationPlayedEvent { get; }

    void PlayDeathAnimation();
   
}