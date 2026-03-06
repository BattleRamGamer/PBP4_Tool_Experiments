using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TargetAimer : MonoBehaviour
{
    [Range(0f, 3f)]
    [SerializeField] private float xMoveMultiplier, yMoveMultiplier;

    [SerializeField] private float sliderMoveDuration;
    [SerializeField] private float dartMoveDuration;

    private enum AimState
    {
        idle, horizontal, vertical, thrown
    }


    [Header("Debug")]
    [SerializeField] private AimState aimState;
    [SerializeField] private float xPos;
    [SerializeField] private float yPos;

    [Header("Assign objects")]
    [SerializeField] private Slider _horizontalSlider;
    [SerializeField] private Slider _verticalSlider;
    [SerializeField] private Transform _dart;

    private void Start()
    {
        _horizontalSlider.DOValue(1f, sliderMoveDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        _verticalSlider.DOValue(1f, sliderMoveDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    void Update()
    {
        
        if (aimState == AimState.horizontal)
        {
            xPos = (_horizontalSlider.value - .5f) * 2 * xMoveMultiplier;
            _dart.Translate(xPos - _dart.position.x, 0, 0);
        }
        if (aimState == AimState.vertical)
        {
            yPos = (_verticalSlider.value - .5f) * 2 * yMoveMultiplier;
            _dart.Translate(0, yPos - _dart.position.y, 0);
        }

    }

    public void NextState()
    {
        switch (aimState)
        {
            case AimState.idle: aimState = AimState.horizontal; break;
            case AimState.horizontal: aimState = AimState.vertical; break;
            case AimState.vertical: aimState = AimState.thrown;
                ThrowDart();
                break;
            //case AimState.thrown: aimState = AimState.idle; break;

        }
    }

    private void ThrowDart()
    {
        _dart.DOPunchPosition(Vector3.forward*3, dartMoveDuration, 0, .2f).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            aimState = AimState.idle;

            _dart.DOMove(new Vector3(3, -3, -3), .5f);

        });
    }
}
