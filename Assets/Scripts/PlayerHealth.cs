using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] PlayerSo data;
    private float invulneravilityTime;
    private float invulneravilityCounter = 0;
    private float contactDamage;
    public static event Action OnUpdateHealth;

    private void Start()
    {
        invulneravilityTime = data.invulneravilityTime;
        contactDamage = data.contactDamage;
    }
    private void Update()
    {
        invulneravilityCounter -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemigos") && invulneravilityCounter < 0)
        {
            TakeDamage(contactDamage);
            invulneravilityCounter = invulneravilityTime;
        }
    }

    public void TakeDamage(float damage)
    {
        PlayerGameManager.playerHealth -= damage;
        OnUpdateHealth.Invoke();
    }
}
