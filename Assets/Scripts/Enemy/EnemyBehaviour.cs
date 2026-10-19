using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private EnemyDataSo data;
    [SerializeField] private PickPoints pickables;
    [SerializeField] private AudioSource deadEffect;
    [SerializeField] private AudioClip[] deadClipEffect;
    private int picksDropped;

    private void Start()
    {
        picksDropped = data.picksDropped;
    }

    public void Drop() 
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        deadEffect.PlayOneShot(deadClipEffect[Random.Range(0,3)]);
        for (int i = 0; i < picksDropped; i++)
        {
            Instantiate(pickables, transform.position, Quaternion.identity);
        }
        particle.Play();
    }

    public void DestroyIm() 
    {
        Destroy(gameObject);
    }

}
