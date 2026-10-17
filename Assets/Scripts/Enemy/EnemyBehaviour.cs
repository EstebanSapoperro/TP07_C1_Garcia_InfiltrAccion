using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyDataSo data;
    [SerializeField] private PickPoints pickables;
    private int picksDropped;

    private void Start()
    {
        picksDropped = data.picksDropped;
    }

    public void Drop() 
    {
        for (int i = 0; i < picksDropped; i++)
        {
            Instantiate(pickables, transform.position, Quaternion.identity);
        }
    }

    public void DestroyIm() 
    {
        Destroy(gameObject);
    }

}
