using UnityEngine;
using DG.Tweening;

public class Shape : MonoBehaviour
{
    [SerializeField] private Transform _innerShape, _outerShape;
    [SerializeField] private float _cycleLength = 2f;


    void Start()
    {
        transform.DOMove(new Vector3(10, 0, 0), _cycleLength).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);

        _innerShape.DORotate(new Vector3(0, 360, 0), _cycleLength * .5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);

        _innerShape.DOLocalMove(new Vector3(0, -3, 0), _cycleLength * .5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);

    }


}
