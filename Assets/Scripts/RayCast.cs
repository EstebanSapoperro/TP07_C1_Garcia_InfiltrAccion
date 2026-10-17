using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] private EnemyMovement enemy;
    [SerializeField] private bool collitionChangeDirection;


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collitionChangeDirection == false) 
        {
            enemy.ChangeDirection();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collitionChangeDirection) 
        {
            enemy.ChangeDirection();
        }
    }
}
