using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/Data/Enemy")]
public class EnemyDataSo : ScriptableObject
{
    [SerializeField] public float orizontalVelocity = 1;
    [SerializeField] public float enemyHealth = 100;
}
