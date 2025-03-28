using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    [SerializeField] private int _gridSize = 4; 
    private Cell[,] _cells;

    private void Start()
    {
        InitializeField();
        SpawnInitialCells();
    }

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

    private void SpawnInitialCells()
    {
        SpawnRandomCell(2);
        SpawnRandomCell(2);
    }

    private void SpawnRandomCell(int value)
    {
        var emptyCells = GetEmptyCells();
        if (emptyCells.Count == 0) return;

        var randomCell = emptyCells[Random.Range(0, emptyCells.Count)];
        randomCell.Value = value;
    }

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