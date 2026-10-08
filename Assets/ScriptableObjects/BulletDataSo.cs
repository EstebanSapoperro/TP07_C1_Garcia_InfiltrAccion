using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "Game/Data/Bullet")]
public class BulletDataSo : ScriptableObject
{
    [SerializeField] public float lifeTime = 2;
    [SerializeField] public float speed = 1f;

}
