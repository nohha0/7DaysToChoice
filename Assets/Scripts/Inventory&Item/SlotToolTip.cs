using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotToolTip : MonoBehaviour
{
    [SerializeField]
    GameObject toolTip_Base;
    Text txt_ItemName;
    Text txt_ItemDesc;
    
    public float tooltip_width;
    public float tooltip_height;

    private void Start()
    {
        toolTip_Base = transform.GetChild(0).gameObject;
        txt_ItemName = toolTip_Base.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        txt_ItemDesc = toolTip_Base.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>();
    }

    public void ShowToolTip(Item _item, Vector3 _pos)
    {
        toolTip_Base.SetActive(true);

        _pos += new Vector3(tooltip_width, tooltip_height, 0);

        toolTip_Base.transform.position = _pos;
        txt_ItemName.text = _item.name;
        txt_ItemDesc.text = _item.explain;
    }

    public void HideToolTip()
    {
        toolTip_Base.SetActive(false);
    }
}
