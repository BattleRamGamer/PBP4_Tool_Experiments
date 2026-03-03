using UnityEngine;
using DG.Tweening;
public class TestDotween : MonoBehaviour
{

    [SerializeField] float movement;
    [SerializeField] float duration;




    public void MoveX(float pMovement)
    {
        transform.DOMoveX(transform.position.x + pMovement, duration);
    }
    public void MoveY(float pMovement)
    {
        transform.DOMoveY(transform.position.y + pMovement, duration);
    }
}
