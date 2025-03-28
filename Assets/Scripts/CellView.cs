using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _valueText;
    [SerializeField] private Image _background;

    // Привязка к data-модели Cell
    public void Bind(Cell cell)
    {
        // Обновляем вид при изменении значения
        cell.OnValueChanged += (value) =>
        {
            _valueText.text = value.ToString();
            // Здесь можно менять цвет и т.д.
        };

        // Обновляем позицию на поле (если нужно)
        cell.OnPositionChanged += (position) =>
        {
            // Логика перемещения (анимация или мгновенное обновление позиции)
            transform.localPosition = new Vector3(position.x * 100, position.y * 100, 0);
        };
    }
}