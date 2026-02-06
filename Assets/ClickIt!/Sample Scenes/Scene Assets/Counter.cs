using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] protected Text textField;
    protected int count = 0;

    public void IncrementCounter(int increment = 1) {
        count += increment;
        textField.text = count.ToString();
    }

    public void DecrementCounter(int decrement = 1) {
        count -= decrement;
        textField.text = count.ToString();
    }

    public void SetCounter(int count) {
        this.count = count;
        textField.text = count.ToString();
    }
}