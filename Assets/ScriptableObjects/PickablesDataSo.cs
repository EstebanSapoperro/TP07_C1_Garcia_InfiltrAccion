using UnityEngine;
[CreateAssetMenu(fileName = "PickData", menuName = "Game/Data/Pick")]
public class PickablesDataSo : ScriptableObject
{
    [SerializeField] public float xImpulse;
    [SerializeField] public float jumpForce;
    [SerializeField] public int ammoDropped;
}
