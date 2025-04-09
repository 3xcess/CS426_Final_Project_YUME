using UnityEngine;
public class ScrollFloor : MonoBehaviour
{
    public float speedX = 0.05f;
    public float speedY = 0.02f;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float x = Time.time * speedX;
        float y = Time.time * speedY;
        rend.material.mainTextureOffset = new Vector2(x, y);
    }
}
