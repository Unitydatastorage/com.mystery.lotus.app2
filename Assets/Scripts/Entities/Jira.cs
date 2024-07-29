using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Entities
{
    public class Jira : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [FormerlySerializedAs("id")] [SerializeField] private int jirai;
        [FormerlySerializedAs("deadZone")] [SerializeField] private float mveREfl;
        [FormerlySerializedAs("destroyScaling")] [SerializeField] private float scalDesrt = 0.85f;
        
        public int Jirai => jirai;

        private Vector2 _sdp1;
        private bool _mv3 = false;
        private bool _iDstr1 = false;
        private float _lDrstr12;

        public event Action<Jira> OnClick;
        public event Action<Jira, Vector2> OnDragged;


        public void MoveToCenter(float drt2)
        {
            _mv3 = true;
            _lDrstr12 = drt2;
            StartCoroutine(MoveToCenterCoroutine(drt2));
        }

        private IEnumerator MoveToCenterCoroutine(float drt2)
        {
            Vector3 stp2 = transform.localPosition;
            float pdt120 = 0;

            while (pdt120 <= drt2)
            {
                pdt120 += Time.deltaTime;
                transform.localPosition = stp2 * (1 - pdt120 / drt2);

                yield return null;
            }

            transform.localPosition = Vector3.zero;
            _mv3 = false;
        }

        private void OnDisable()
        {
            if (_iDstr1)
                Destroy(gameObject);
        }

        public void Destroy(float duration)
        {
            _iDstr1 = true;
            _lDrstr12 = duration;
            StartCoroutine(DestroyCoroutine(duration));
        }

        private IEnumerator DestroyCoroutine(float drt2)
        {
            float pdt4 = 0;

            while (pdt4 <= drt2)
            {
                pdt4 += Time.deltaTime;
                transform.localScale = Vector3.one * (scalDesrt * pdt4 / drt2);

                yield return null;
            }
            
            Destroy(gameObject);
            _iDstr1 = false;
        }

        public void Svrwq()
        {
            if (_mv3)
                MoveToCenter(_lDrstr12);

            if (_iDstr1)
                Destroy(_lDrstr12);
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            return;
            
            OnClick.Invoke(this);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _sdp1 = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Vector2 dgp34 = eventData.position - _sdp1;

            if (dgp34.magnitude <= mveREfl)
                return;
            
            OnDragged.Invoke(this, dgp34.normalized);
        }
    }
}