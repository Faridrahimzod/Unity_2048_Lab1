using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    [SerializeField] private int _gridSize = 4; // Размер поля (4x4)
    private Cell[,] _cells; // Двумерный массив клеток

    private void Start()
    {
        InitializeField();
        SpawnInitialCells();
    }

    // Инициализация пустого поля
    private void InitializeField()
    {
        _cells = new Cell[_gridSize, _gridSize];

        for (int x = 0; x < _gridSize; x++)
        {
            for (int y = 0; y < _gridSize; y++)
            {
                _cells[x, y] = new Cell(new Vector2Int(x, y));
            }
        }
    }

    // Создание начальных клеток (2 клетки со значением 2)
    private void SpawnInitialCells()
    {
        SpawnRandomCell(2);
        SpawnRandomCell(2);
    }

    // Создание клетки со случайной позицией
    private void SpawnRandomCell(int value)
    {
        // Получаем список пустых клеток
        var emptyCells = GetEmptyCells();
        if (emptyCells.Count == 0) return;

        // Выбираем случайную клетку
        var randomCell = emptyCells[Random.Range(0, emptyCells.Count)];
        randomCell.Value = value;
    }

    // Получение списка пустых клеток
    private List<Cell> GetEmptyCells()
    {
        List<Cell> empty = new List<Cell>();
        foreach (var cell in _cells)
        {
            if (cell.Value == 0) empty.Add(cell);
        }
        return empty;
    }
}