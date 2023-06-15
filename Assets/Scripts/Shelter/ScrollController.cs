using UnityEngine;

public class ScrollController : MonoBehaviour
{
    public float scrollSpeed = 5.0f;

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float scrollDistance = -scroll * scrollSpeed * Time.deltaTime;

        transform.Translate(0, scrollDistance, 0);
    }
}
