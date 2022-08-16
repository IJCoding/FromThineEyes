using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
[HelpURL("https://github.com/IJCoding/FromThineEyes/issues/6")]
[CreateAssetMenu(fileName = "newStat", menuName = "Stats")]
public class Stat : ScriptableObject
{
    [SerializeField]    private int _min;
    [SerializeField]    private int _cur;
    [SerializeField]    private int _max;

    private void OnEnable()
    {
        RedefineBounds(0, 12);
        SetCur(6);        
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