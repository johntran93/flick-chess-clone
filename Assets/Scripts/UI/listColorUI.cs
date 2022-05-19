using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listColorUI : MonoBehaviour
{
    public static listColorUI Instance;

    [SerializeField] private List<ItemColor> _ListItem = new List<ItemColor>();
    public List<ItemColor> ListItem => _ListItem;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
