using UnityEngine;
using DG.Tweening;
public class TestDotween : MonoBehaviour
{

    [SerializeField] float movement;
    [SerializeField] float duration;

    Tween tween;

    private void Update()
    {
        tween.OnComplete(BackToStart);
    }

    private void BackToStart()
    {
        transform.DOMoveX(Screen.width / 2, duration);
    }

    public void MoveX(float pMovement)
    {
        tween = transform.DOMoveX(Screen.width/2 + pMovement, duration).From(Screen.width/2);
    }
    public void MoveY(float pMovement)
    {
        transform.DOMoveY(transform.position.y + pMovement, duration);
    }
}
