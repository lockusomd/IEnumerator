using System.Collections;
using UnityEngine;
using TMPro;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private Counter _counter = new Counter();
    private Coroutine _coroutine;

    private bool _isCount = false;
    private int _delayInSeconds = 1;

    private void Start()
    {
        _text.text = "0";
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCount)
            {
                StopCoroutine(_coroutine);

                _isCount = false;
            }
            else
            {
                _coroutine = StartCoroutine(Increase(_delayInSeconds));

                _isCount = true;
            }
        }
    }

    private IEnumerator Increase(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (true)
        {
            DisplayCount();

            yield return wait;
        }
    }

    private void DisplayCount()
    {
        _text.text = _counter.IncreaseCount().ToString();
    }
}
