using UnityEngine;

public class AudioManagerSFX : MonoBehaviour
{
    [SerializeField] private AudioSource sfxAudio;
    [SerializeField] private AudioClip missClipEffect;
    private void Start()
    {
        BulletMovement.OnMissShoot += PlayMissSound;
    }

    private void OnDestroy()
    {
        BulletMovement.OnMissShoot -= PlayMissSound;
    }

    private void PlayMissSound() 
    {
        sfxAudio.PlayOneShot(missClipEffect);
    }

}
