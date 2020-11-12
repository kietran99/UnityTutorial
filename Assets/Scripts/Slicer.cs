using UnityEngine;

public class Slicer : MonoBehaviour
{
    private CircleCollider2D myCollider;

    void Start()
    {
        myCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ToggleCollider(false);
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        ToggleCollider(true);
        DragSlicer();
    }

    private void ToggleCollider(bool shouldAppear)
    {
        myCollider.enabled = shouldAppear;
    }

    private void DragSlicer()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
    }
}
