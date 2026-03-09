using UnityEngine;

public class DotweenDart : MonoBehaviour
{
    [SerializeField] private float readyCooldown;
    [SerializeField] private bool isReady = true;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision " + other.name);
        if (!isReady) { return; }

        if (other.TryGetComponent(out DotweenTargetCircle target))
        {
            DotweenPointManager.Instance.ScorePoints(target.GetPoints());
            isReady = false;
            Invoke(nameof(DoReadyCooldown), readyCooldown);
        }
    }

    private void DoReadyCooldown()
    {
        isReady = true;
    }
}
