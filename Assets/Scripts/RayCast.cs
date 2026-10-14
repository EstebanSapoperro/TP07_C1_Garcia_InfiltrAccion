using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] EnemyMovement enemy;

    void FixedUpdate()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null) 
        { 
        }

        if (collision == null)
        {
        }

        enemy.ChangeDirection();
    }
}
