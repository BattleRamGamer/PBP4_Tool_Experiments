using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class FeaturesManager : MonoBehaviour
{
    [SerializeField] private Transform _jumper, _puncher, _shaker, _target;
    [SerializeField] private MeshRenderer _changer;


    private void Start()
    {
        DOVirtual.Float(0, 10, 3, v =>
        {
            print(v);
        }).SetEase(Ease.InBounce).SetLoops(-1, LoopType.Yoyo);
    }


    public void Jump()
    {
        _jumper.DOLocalJump(
            endValue: new Vector3(-2.2f, 1, 0),
            jumpPower: 3,
            numJumps: 1,
            duration: .5f).SetEase(Ease.InOutSine);
    }

    public void Shake()
    {
        const float duration = .5f;
        const float strength = .5f;

        // This is to prevent not returning to orinigal values. Needs to be global
        //var tween = _shaker.DOShakePosition(duration, strength);
        //if (tween.IsPlaying()) return;

        _shaker.DOShakePosition(duration, strength);
        _shaker.DOShakeRotation(duration, strength);
        _shaker.DOShakeScale(duration, strength);
    }

    public void Punch()
    {
        var duration = .5f;

        _puncher.DOPunchPosition(
            punch: Vector3.left * 2,
            duration: duration,
            vibrato: 0,
            elasticity: 0);

        _target.DOShakePosition(
            duration: .5f,
            strength: .5f,
            vibrato: 10).SetDelay(duration * .5f);
    }

    public void Change()
    {
        _changer.material.DOColor(Random.ColorHSV(), .5f).OnComplete(Change);
    }






}
