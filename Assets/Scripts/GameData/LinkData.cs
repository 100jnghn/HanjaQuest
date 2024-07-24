using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

using UnityEngine;



[System.Serializable]
public class LinkData : MonoBehaviour
{
    [SerializeField]
    public List<DictionaryEntry<string, Data>> hanjaDataList = new List<DictionaryEntry<string, Data>>(); //�����ͻ󿡼� �߰� o
}

[System.Serializable]
public class DictionaryEntry<TKey, TValue> //�׳� ��ųʸ� ������Ʈ�� �����Ϳ��� ���������� ���� �ȵż� ��ųʸ� ��Ʈ�� ���� ���� ����Ʈ ���·� ����
{
    [SerializeField]
    public TKey key;

    [SerializeField]
    public TValue value;
}