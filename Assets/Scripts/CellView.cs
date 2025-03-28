using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _valueText;
    [SerializeField] private Image _background;

    public void Bind(Cell cell)
    {
        cell.OnValueChanged += (value) =>
        {
            _valueText.text = value.ToString();
        };

        cell.OnPositionChanged += (position) =>
        {
            transform.localPosition = new Vector3(position.x * 100, position.y * 100, 0);
        };
    }
}