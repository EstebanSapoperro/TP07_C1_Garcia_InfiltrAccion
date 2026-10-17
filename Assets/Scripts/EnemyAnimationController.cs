using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyMovement movement;
    [SerializeField] private EnemyBehaviour behaviour;
    [SerializeField] private EnemyShotDetection enemyShotDetection;

    public void Stop() 
    {
        movement.Stop();
    }

    public void Continue()
    {
        movement.Continue();
    }
    public void Drop()
    {
        behaviour.Drop();
    }
    public void DestroyIm()
    {
        behaviour.DestroyIm();
    }

    public void Shot() 
    {
        enemyShotDetection.Shot();
    }
    public void NotShot()
    {
        enemyShotDetection.CanShot(false);
    }

    public void Walk()
    {
        animator.Play("EnemyAnimation");
    }

    public void YesShot()
    {
        enemyShotDetection.CanShot(true);
    }
}
