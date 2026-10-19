using UnityEngine;
using System;
public class WinCondition : MonoBehaviour
{
    public static event Action OnWining;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnWining?.Invoke();
        }
    }
}
