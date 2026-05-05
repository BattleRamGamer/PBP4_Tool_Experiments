using UnityEngine;
using UnityEngine.Events;

public class DoorButton : MonoBehaviour
{

    [SerializeField]
    private UnityEvent onCollisionEvent;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.ToLower() != "player") return;
        onCollisionEvent?.Invoke();
    }
}
