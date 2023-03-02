using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Text _counter;
    [SerializeField] private GameObject _mouse;
    private int _count;
    private GameObject _currentMouse;

    void Start()
    {
        _count = 0;
        _currentMouse =Instantiate(_mouse) as GameObject;
        _currentMouse.transform.position = new Vector3(0, 0.1f, 0);
        _currentMouse.GetComponent<Mouse>().OnSlam += CountUp;
        DisplayCount();
    }

    private void DisplayCount()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(_count.ToString());
        sb.Append("‰ñ");
        _counter.text = sb.ToString();
    }

    private void CountUp()
    {
        _count++;
        DisplayCount();
    }

    public void OnClickResetButton()
    {

        _currentMouse.GetComponent<Mouse>().OnSlam -= CountUp;
        Destroy(_currentMouse);
        _currentMouse = Instantiate(_mouse) as GameObject;
        _currentMouse.transform.position = new Vector3(0, 0.1f, 0);
        _currentMouse.GetComponent<Mouse>().OnSlam += CountUp;
    }
}
