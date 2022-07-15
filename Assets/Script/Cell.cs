using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private Text _view = null;
    [SerializeField]
    private CellState _cellState = CellState.None;
    [SerializeField]
    private GameObject _cellCover = default;
    bool digg = false;
    public CellState CellState
    {
        get => _cellState;
        set
        {
            _cellState = value;
            OnCellStateChanged();
        }
    }

    private void OnValidate()
    {
        OnCellStateChanged();
    }
    private void FixedUpdate()
    {
        if(digg == true)
        {
            if (_cellState== CellState.Mine)
            {
                digg = false;
                Debug.Log("Bomb!");
                Destroy(this);
            }
        }
    }

    private void OnCellStateChanged()
    {
        if (_view == null) { return; }

        if (_cellState == CellState.None)
        {
            _view.text = "";
        }
        else if (_cellState == CellState.Mine)
        {
            _view.text = "X";
            _view.color = Color.red;
        }
        else
        {
            _view.text = ((int)_cellState).ToString();
            _view.color = Color.blue;
        }
    }
    public void Digout()
    {
        digg = true;
    }
}