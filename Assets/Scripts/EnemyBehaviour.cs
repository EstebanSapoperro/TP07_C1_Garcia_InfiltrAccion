using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Pickables pickables;
    private void Start()
    {
        
    }

    private void OnDestroy()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(pickables, transform.position, Quaternion.identity);
        }
    }
    private void Update()
    {
        
    }
}
