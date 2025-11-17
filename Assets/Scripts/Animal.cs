using Unity.VisualScripting;
using UnityEngine;

public class Animal : ARInteractableObject
{
    private Animator _animator;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void SetState(State state)
    {
        base.SetState(state);

        switch (state)
        {
            case State.Idle:
                _animator.Play("Idle");
                break;
            case State.Active:
                // _animator.Play("Kittie_idle");
                break;

            default:
                break;
        }
    }
}
