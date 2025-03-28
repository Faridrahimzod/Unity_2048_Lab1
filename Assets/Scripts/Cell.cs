using UnityEngine;
using System; // Для работы с событиями (Action)

// Класс НЕ наследует MonoBehaviour (это data-класс)
[Serializable]
public class Cell
{
    // События
    public event Action<int> OnValueChanged; // Передает новое значение
    public event Action<Vector2Int> OnPositionChanged; // Передает новую позицию

    [SerializeField] private int _value;
    [SerializeField] private Vector2Int _position;

    // Свойство для значения клетки
    public int Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;
                OnValueChanged?.Invoke(_value); // Вызываем событие
            }
        }
    }

    // Свойство для позиции клетки
    public Vector2Int Position
    {
        get => _position;
        set
        {
            if (_position != value)
            {
                _position = value;
                OnPositionChanged?.Invoke(_position); // Вызываем событие
            }
        }
    }

    // Конструктор для инициализации
    public Cell(Vector2Int position, int value = 0)
    {
        _position = position;
        _value = value;
    }
}