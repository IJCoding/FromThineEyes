using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
[HelpURL("https://github.com/IJCoding/FromThineEyes/issues/6")]
public class Stat : MonoBehaviour
{
    [SerializeField]    private int _min = 0;
    [SerializeField]    private int _cur = 0;
    [SerializeField]    private int _max = 0;

    public Stat(int defMin = 0, int defCur = 0, int defMax = 0)
    {
        RedefineBounds(defMin, defMax);
        AlterCur(defCur);
    }

    public void RedefineBounds(int newMin, int newMax)
    {
        //Check data was correctly input...
       if(newMin <= newMax)
        {
            _min = newMin;
            _max = newMax;
        }
        else //...if incorrect swap values and call recursivley
        {
            RedefineBounds(newMax, newMin);
        }
    }

    public void SetCur(int newCur)
    {
        if (newCur <= _max && newCur >=_min) _cur = newCur;
        else
        {
            if (_cur >= _max)
            {
                Debug.Log("Error: Attempted to set cur value above maximum -> " + this.name + " set to max value.");
                _cur = _max;
                
            }
            else
            {
                Debug.Log("Error: Attempted to set cur value below minimum -> " + this.name +  " set to min value.");
                _cur = _min;
            }
        }
    }

    public void AlterCur(int changeAmount) { SetCur(GetCur() + changeAmount); }

    public int GetCur() { return _cur; }
    public int GetMax() { return _max; }
    public int GetMin() { return _min; }

}
