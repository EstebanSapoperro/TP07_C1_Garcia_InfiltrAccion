using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private EnemyMovement movement;
    [SerializeField] private EnemyBehaviour behaviour;

    public void Stop() 
    {
        movement.Stop();
    }
    public void Drop()
    {
        behaviour.Drop();
    }
    public void DestroyIm()
    {
        behaviour.DestroyIm();
    }
}
