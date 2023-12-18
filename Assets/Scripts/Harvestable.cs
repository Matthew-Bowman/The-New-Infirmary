using UnityEngine;
using UnityEngine.Events;

public class Harvestable : MonoBehaviour
{
    [SerializeField] private int _health = 10;
    [SerializeField] Resource resource;
    [SerializeField] UnityEvent<Resource> statusEvent;

    private Animator anim;
    private bool hittable = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Hit()
    {
        if (hittable)
        {
            anim.SetTrigger("Hit");
            _health--;

            if (_health <= 0)
            {
                hittable = false;
                statusEvent.Invoke(resource);
                anim.SetTrigger("Destroy");
            }
        }
    }

    public void DestroyResource()
    {
        Destroy(this);
    }
}
