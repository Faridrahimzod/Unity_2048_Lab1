using UnityEngine;
using System;

[Serializable]
public class Cell
{
    public event Action<int> OnValueChanged; 
    public event Action<Vector2Int> OnPositionChanged; 

    [SerializeField] private int _value;
    [SerializeField] private Vector2Int _position;

    public int Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;
                OnValueChanged?.Invoke(_value); 
            }
        }
    }

    public Vector2Int Position
    {
        get => _position;
        set
        {
            if (_position != value)
            {
                _position = value;
                OnPositionChanged?.Invoke(_position); 
            }
        }
    }

    public Cell(Vector2Int position, int value = 0)
    {
        _position = position;
        _value = value;
    }
}