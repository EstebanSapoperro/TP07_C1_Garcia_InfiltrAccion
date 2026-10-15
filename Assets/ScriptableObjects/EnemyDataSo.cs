using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/Data/Enemy")]
public class EnemyDataSo : ScriptableObject
{
    [SerializeField] public float velocityX = 1;
}
