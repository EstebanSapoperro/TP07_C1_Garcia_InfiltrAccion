using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private PickPoints pickables;


    public void Drop() 
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(pickables, transform.position, Quaternion.identity);
            
        }
    }

    public void DestroyIm() 
    {
        Destroy(gameObject);
    }

}
