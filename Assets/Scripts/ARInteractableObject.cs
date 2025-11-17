using System;
using System.Collections.Generic;
using UnityEngine;

public class ARInteractableObject : MonoBehaviour
{
    private List<ARInteractableObject> _interactables = new();

    protected enum State
    {
        Idle,
        Active,
    }

    protected State ARObjectState = State.Idle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ARInteractableObject>(out var interactable))
        {
            AddInteractable(interactable);
        }
    }

    protected void AddInteractable(ARInteractableObject interactable)
    {
        _interactables.Add(interactable);
        SetState(State.Active);
    }

    protected void RemoveInteractable(ARInteractableObject interactable)
    {
        _interactables.Remove(interactable);
        if (_interactables.Count == 0)
            SetState(State.Idle);
    }

    protected virtual void SetState(State state)
    {
        ARObjectState = state;
    }

    private void OnDisable()
    {
        foreach (var interactable in _interactables)
        {
            interactable.RemoveInteractable(this);
        }

        _interactables.Clear();
        SetState(State.Idle);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<ARInteractableObject>(out var interactable))
        {
            RemoveInteractable(interactable);
        }
    }
}
