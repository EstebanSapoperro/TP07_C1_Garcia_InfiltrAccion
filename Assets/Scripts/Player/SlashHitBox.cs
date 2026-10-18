using UnityEngine;
using UnityEngine.Audio;

public class SlashHitBox : MonoBehaviour
{
    [SerializeField] private PlayerSo data;
    [SerializeField] private AudioSource slashEffect;
    [SerializeField] private AudioClip slashClipEffect;
    private float slashDamage;
    private void Start()
    {
        slashDamage = data.slashDamage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemigos"))
        {
            HealthComponent enemyLife = other.GetComponentInChildren<HealthComponent>();
            enemyLife.DoDamage(slashDamage);
        }
    }

    public void SlashSoundEffect() 
    {
        slashEffect.pitch = Random.Range(0.9f, 1.1f);
        slashEffect.PlayOneShot(slashClipEffect);
    }
}
