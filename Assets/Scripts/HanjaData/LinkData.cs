using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

using UnityEngine;



[System.Serializable]
public class LinkData : MonoBehaviour
{
    [SerializeField]
    public List<DictionaryEntry<string, Data>> hanjaDataList = new List<DictionaryEntry<string, Data>>(); //에디터상에서 추가 o
}

[System.Serializable]
public class DictionaryEntry<TKey, TValue> //그냥 딕셔너리 오브젝트는 에디터에서 직접적으로 수정 안돼서 딕셔너리 엔트리 따로 만들어서 리스트 형태로 만듬
{
    [SerializeField]
    public TKey key;

    [SerializeField]
    public TValue value;
}