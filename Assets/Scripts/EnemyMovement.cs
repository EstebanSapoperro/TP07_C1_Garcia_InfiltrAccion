
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float velocityX = 1f;
    [SerializeField] private Transform body;
    [SerializeField] private EnemyDataSo data;
    public bool inFloor = true;

    private void Start()
    {
        velocityX = data.velocityX;
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityX = Mathf.Abs(velocityX *2);
    }


    public void ChangeDirection() 
    {
        Vector3 rotacion = body.transform.eulerAngles;
        if (Mathf.Approximately(rotacion.y, 180f))
        {
            rb.linearVelocityX = Mathf.Abs(velocityX);
            body.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            rb.linearVelocityX = -Mathf.Abs(velocityX);
            body.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
