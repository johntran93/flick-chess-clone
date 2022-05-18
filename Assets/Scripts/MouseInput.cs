using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInput : MonoBehaviour,IDragHandler, IBeginDragHandler,IEndDragHandler
{
    private Vector3 _mousePressDownPos;
    private Vector3 _mouseReleasePos;
    private Vector3 forceDir ;
    private float _currentDistance;
    public void OnBeginDrag(PointerEventData eventData)
    {
        _mousePressDownPos = Input.mousePosition;
        //GameManager.Instance.PlayerManager.Indicator_GO.gameObject.SetActive(true);
        //GameManager.Instance.KingChes.Indicator_GO.gameObject.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {   _mouseReleasePos = Input.mousePosition;
        Vector3 _mouseDir = Input.mousePosition;
        float  _currentDistance1 = Vector3.Distance(_mousePressDownPos,_mouseReleasePos);
        //GameManager.Instance.PlayerManager.Indicator(_mousePressDownPos - _mouseDir);
        //GameManager.Instance.KingChes.Indicator(_mousePressDownPos - _mouseDir);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _currentDistance = Vector3.Distance(_mousePressDownPos,_mouseReleasePos);
        if(GameManager.Instance.RaycastCheck.Check().transform == null)
        return;
        if(_currentDistance > 70)
        {
        GameManager.Instance.Shoot(_mousePressDownPos-_mouseReleasePos,GameManager.Instance.RaycastCheck.Check().transform.GetComponent<Rigidbody>());
        }
    }
}
