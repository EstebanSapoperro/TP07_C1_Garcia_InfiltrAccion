using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private PickPoints pickables;

    private void OnDestroy()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(pickables, transform.position, Quaternion.identity);
        }
    }

}
