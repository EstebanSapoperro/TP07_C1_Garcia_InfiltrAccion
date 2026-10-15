using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private GameObject Background;
    private Material paralax;
    [SerializeField] private float velocity = 1;

    private void Start()
    {
        paralax = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        paralax.mainTextureOffset += new Vector2(velocity * Time.deltaTime, 0);
    }
}
