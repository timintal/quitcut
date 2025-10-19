using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace ProceduralUIElements
{


    public class Point_PolygonEditor_PUE : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        public int m_Index;

        public void OnDrag(PointerEventData pointerEventData)
        {
            float _ScaleX = transform.GetComponent<RectTransform>().sizeDelta.x;

            float _MoveSpeed = transform.parent.GetComponent<PolygonEditor_PUE>().m_PointMoveSpeed;
            Vector2 _MouseData = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            Vector2 _Position = transform.GetComponent<RectTransform>().anchoredPosition + _MouseData * _MoveSpeed;

            float _Width = transform.parent.GetComponent<PolygonEditor_PUE>().m_ImageWidth / 2.0f + 20;
            float _Height = transform.parent.GetComponent<PolygonEditor_PUE>().m_ImageHeight / 2.0f + 20;

            float _X = Mathf.Clamp(_Position.x, -_Width, _Width);
            float _Y = Mathf.Clamp(_Position.y, -_Height, _Height);

            _Position = new Vector2(_X, _Y);
            transform.GetComponent<RectTransform>().anchoredPosition = _Position;
            transform.parent.GetComponent<PolygonEditor_PUE>().UpdatePointPosition(m_Index);
        }

        public void OnEndDrag(PointerEventData pointerEventData)
        {

        }

        public void OnPointerDown(PointerEventData pointerEventData)
        {
            transform.parent.GetComponent<PolygonEditor_PUE>().m_IsAnyPointClicked = true;
        }

        public void OnPointerUp(PointerEventData pointerEventData)
        {
            transform.parent.GetComponent<PolygonEditor_PUE>().m_IsAnyPointClicked = false;
        }
    }


}/// namespace

