using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] PlayerSo data;
    [SerializeField] Transform playerPosition;

    [SerializeField] Transform limitsPosition;
    private float invulneravilityTime = 2;
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
        if (playerPosition.localPosition.y < limitsPosition.localPosition.y) 
        {
            Debug.Log("Se murio por que se salio del mapa");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemigos") && invulneravilityCounter < 0)
        {
            TakeDamage(contactDamage);
        }
    }

    public void TakeDamage(float damage)
    {
        invulneravilityCounter = invulneravilityTime;
        Debug.Log("Se recibio daño");
        PlayerGameManager.playerHealth -= damage;
        OnUpdateHealth?.Invoke();
    }
}
