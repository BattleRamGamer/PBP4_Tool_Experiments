using TMPro;
using UnityEngine;

public class DotweenPointManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointText;

    public static DotweenPointManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }
    }

    public void ScorePoints(int pAmount)
    {
        pointText.text = "Scored " + pAmount;
    }


}
