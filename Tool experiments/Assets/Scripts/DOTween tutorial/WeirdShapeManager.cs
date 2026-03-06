using UnityEngine;
using DG.Tweening;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;

public class WeirdShapeManager : MonoBehaviour
{
    [SerializeField] private Transform[] _shapes;


    private void Start()
    {

        //var sequence = DOTween.Sequence();

        //foreach (var shape in _shapes)
        //{
        //    sequence.Append(shape.DOMoveX(10, Random.Range(1f, 2f)));
        //}

        //sequence.OnComplete(() =>
        //{
        //    foreach (var shape in _shapes)
        //    {
        //        shape.DOScale(Vector3.zero, .5f).SetEase(Ease.InBounce);
        //    }
        //});


        // Disastrous code
        //_shapes[0].DOMoveX(10, Random.Range(1f, 2f)).OnComplete(() =>
        //{
        //    _shapes[1].DOMoveX(10, Random.Range(1f, 2f)).OnComplete(() =>
        //    {
        //        _shapes[2].DOMoveX(10, Random.Range(1f, 2f)).OnComplete(() =>
        //        {
        //            foreach (var shape in _shapes)
        //            {
        //                shape.DOScale(Vector3.zero, .5f).SetEase(Ease.InBounce);
        //            }
        //        });
        //    });
        //});


        // AsyncBaby();
        Tasks();
    }


    #region Async Workflow

    async void AsyncBaby()
    {
        foreach (var shape in _shapes)
        {
            await shape.DOMoveX(10, Random.Range(1f, 2f)).SetEase(Ease.InOutQuad).AsyncWaitForCompletion();
        }
    }

    async void Tasks()
    {
        var tasks = new List<Task>();

        foreach (var shape in _shapes)
        {
            tasks.Add(shape.DOMoveX(10, Random.Range(1f, 2f)).SetEase(Ease.InOutQuad).AsyncWaitForCompletion());
        }

        await Task.WhenAll(tasks);

        foreach (var shape in _shapes) shape.DOScale(Vector3.zero, .5f).SetEase(Ease.InBounce);
    }

    #endregion


}
