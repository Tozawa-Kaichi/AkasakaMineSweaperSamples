using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    // C# メソッド宣言
    // 修飾子 戻り値型 メソッド名(パラメータリスト) { 本体 }

    // パラメータを受け取らず、戻り値を返さないメソッド
    // メソッドが呼び出されると、本体 { } のコードを実行する
    // メソッドが終了すると呼び出し元に制御が戻る
    private void M() { Debug.Log("M"); }

    void Start()
    {
        Debug.Log("Begin");
        M(); // M メソッドの呼び出し
        Debug.Log("End");


        // 呼び出し側はパラメータに対応する値を渡す必要がある
        M(1, 2);
        M(123, 456);

        // 戻り値を持つメソッドの呼び出しは、結果を受け取れる
        var r = Add(10, 20); // r 変数に戻り値が入る
        Debug.Log($"r={r}");

        // ただし、戻り値を無視することもできる
        Add(123, 456); // OK

        M(10);//再起処理
    }
    // 階層的なメソッドの呼び出し
// メソッドから、別のメソッドを自由に呼び出すことができる
// メソッドを多段階に呼び出しても、必ず最初の呼び出し元まで復帰する
    private void X()
    {
        Debug.Log("Begin X");
        Y();
        Debug.Log("End X");
    }
    private void Y()
    {
        Debug.Log("Begin Y");
        Z();
        Debug.Log("End Y");
    }
    private void Z() { Debug.Log("Z"); }

    // メソッド パラメータ
    // メソッドは呼び出し元から、任意の値を受け取ることができる。
    // 呼び出し側は、メソッドの実行に必要な参考値などを渡せる。
    // (パラメータ型1 パラメータ名1, パラメータ型2 パラメータ名2, ...)

    // int 型のパラメータ x と y を受け取るメソッド
    private void M(int x, int y)
    {
        Debug.Log($"M x={x}, y={y}");
    }


    // メソッドの戻り値
    // メソッドは処理の結果を呼び出し元に返すことができる
    // 戻り値型が void の場合、何も返さないことを表す
    // void 以外の場合 return 文で値を返さなければならない
    private int Add(int x, int y)
    {
        Debug.Log($"Add x={x}, y={y}");
        return x + y; // x + y を結果として返す
    }

    //private void M()
    //{
    //    Debug.Log("M");

    //    // メソッドは、自分自身を呼び出すことができる
    //    M(); // ただし、無条件だと無限に自分を呼び出し続ける=>無限ループ
    //}

    private void M(int count)
    {
        if (count <= 0)
        {
            Debug.Log($"Return M: count={count}");
            return;
        }

        Debug.Log($"Begin M: count={count}");
        M(count - 1);
        Debug.Log($"End M: count={count}");
    }
}
