using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletParent;

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Interaction();
        }
    }

    void Interaction()
    {
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null && hit.transform.CompareTag("Resource"))
            hit.transform.SendMessage("Hit");
        else
        {
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.parent = bulletParent.transform;
            newBullet.transform.position = transform.position;
        }
    }
}
