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
    private bool isDeath = false;
    public static event Action OnUpdateHealth;
    public static event Action OnDeathHealth;

    private void Start()
    {
        invulneravilityTime = data.invulneravilityTime;
        contactDamage = data.contactDamage;
    }
    private void Update()
    {
        invulneravilityCounter -= Time.deltaTime;
        if (playerPosition.localPosition.y < limitsPosition.localPosition.y && isDeath == false) 
        {
            Debug.Log("Se murio por que se salio del mapa");
            isDeath = true;
            OnDeathHealth?.Invoke();
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
        if (PlayerGameManager.playerHealth <= 0)
        {
            OnDeathHealth?.Invoke();
        }
        else 
        {
            OnUpdateHealth?.Invoke();
        }
       
    }
}
