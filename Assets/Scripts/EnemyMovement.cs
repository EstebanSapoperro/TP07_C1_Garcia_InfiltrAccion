
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float volocityx = 1f;
    [SerializeField] Transform body;
    public bool inFloor = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityX = Mathf.Abs(volocityx *2);
    }

    public void ChangeDirection() 
    {
        Debug.Log("no esta en el suelo");

        Vector3 rotacion = body.transform.eulerAngles;

        //if (transform.rotation.y == -180)
        //{
        //    rb.linearVelocityX = volocityx;
        //    Debug.Log("cambio de direccion a la derecha");
        //    transform.right = new Vector3(0, 0, 0);
        //}

        //if (transform.rotation.y == 0)
        //{
        //    Debug.Log("cambio de direccion a la izquierda");
        //    transform.right = new Vector3(-180, 0, 0);
        //}

        if (Mathf.Approximately(rotacion.y, 180f))
        {
            rb.linearVelocityX = Mathf.Abs(volocityx);
            Debug.Log("Cambio de dirección a la derecha");

            body.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            rb.linearVelocityX = -Mathf.Abs(volocityx);
            Debug.Log("Cambio de dirección a la izquierda");

            body.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }
}
