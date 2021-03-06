using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Minesweeper : MonoBehaviour 
{
    [SerializeField]
    private int _rows = 1;

    [SerializeField]
    private int _columns = 1;

    [SerializeField]
    private int _mineCount = 1;

    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup = null;

    [SerializeField]
    private Cell _cellPrefab = null;

    public static bool danger = false;
    private void Start()
    {
        _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _gridLayoutGroup.constraintCount = _columns;

        var cells = new Cell[_rows, _columns];
        var parent = _gridLayoutGroup.transform;
        for (var r = 0; r < _rows; r++)
        {
            for (var c = 0; c < _columns; c++)
            {
                var cell = Instantiate(_cellPrefab);
                cell.transform.SetParent(parent);
                cells[r, c] = cell;
            }
        }

        // セルを初期化して地雷をランダムに設置する。
        ClearCells(cells, _mineCount);

        // すべてのセルを探索する2重ループ
        for (var r = 0; r < _rows; r++)
        {
            for (var c = 0; c < _columns; c++)
            {
                // このセルの周囲8マスの地雷を数える
                var cell = cells[r, c];
                cell.CellState = GetMineCount(cells, r, c);
            }
        }
    }
    private void FixedUpdate()
    {
        if(danger)
        {
            danger = false;
            SceneManager.LoadScene("SampleScene");
        }
    }
    /// <summary>
    /// 指定した2次元配列のセルをすべて初期化して、指定数の地雷をランダムに配置する。
    /// 地雷数がセル数より多い場合、すべてのセルを地雷で埋める。
    /// </summary>
    /// <param name="cells">セルの2次元配列。</param>
    /// <param name="mineCount">設置する地雷数。</param>
    private void ClearCells(Cell[,] cells, int mineCount)
    {
        // すべてのセルの状態を None で初期化する
        foreach (var cell in cells) { cell.CellState = CellState.None; }

        // 設定された地雷数がセル数より多い場合
        if (mineCount > cells.Length)
        {
            // 地雷数を強制的にセル数と一致させる
            mineCount = cells.Length;
        }

        var rows = cells.GetLength(0);
        var columns = cells.GetLength(1);

        // 設置したい地雷数（mineCount）だけ繰り返す
        for (var i = 0; i < mineCount;)
        {
            // ランダムな行番号 r、列番号 c を取る
            var r = Random.Range(0, rows);
            var c = Random.Range(0, columns);

            // ランダムに選ばれたセル
            var cell = cells[r, c];
            if (cell.CellState != CellState.Mine)
            {
                i++; // カウンターをインクリメントする
                cell.CellState = CellState.Mine;
            }
            else { Debug.Log("地雷再抽選"); }
        }
    }

    /// <summary>
    /// 指定した2次元配列の r 行 c 列にあるセルの周囲8近傍の地雷数を取得する。
    /// r 行 c 列のセルが地雷なら <see cref="CellState.Mine"/> を返す。
    /// </summary>
    /// <param name="cells">セルの2次元配列。</param>
    /// <param name="r">行番号。</param>
    /// <param name="c">列番号。</param>
    /// <returns>セルの周囲8近傍の地雷数。</returns>
    private CellState GetMineCount(Cell[,] cells, int r, int c)
    {
        var cell = cells[r, c];
        if (cell.CellState == CellState.Mine)
        {
            return CellState.Mine;  // 地雷セルは無視する
        }

        var count = 0;

        // セルの周囲の地雷数を数える処理
        if (r - 1 >= 0)
        {
            if (c - 1 >= 0 && cells[r - 1, c - 1].CellState == CellState.Mine) { count++; }
            if (cells[r - 1, c].CellState == CellState.Mine) { count++; }
            if (c + 1 < _columns && cells[r - 1, c + 1].CellState == CellState.Mine) { count++; }
        }
        if (c - 1 >= 0 && cells[r, c - 1].CellState == CellState.Mine) { count++; }
        if (c + 1 < _columns && cells[r, c + 1].CellState == CellState.Mine) { count++; }
        if (r + 1 < _rows)
        {
            if (c - 1 >= 0 && cells[r + 1, c - 1].CellState == CellState.Mine) { count++; }
            if (cells[r + 1, c].CellState == CellState.Mine) { count++; }
            if (c + 1 < _columns && cells[r + 1, c + 1].CellState == CellState.Mine) { count++; }
        }
        return (CellState)count; // 地雷数を CellState に変換
    }
    
}