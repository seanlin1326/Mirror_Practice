using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace HowTungTung
{
    public class HorizontalInfiniteScrollView : InfiniteScrollView
    {
        public bool isAtLeft = true;
        public bool isAtRight = true;

        public override void Initialize()
        {
            base.Initialize();
            isAtLeft = true;
            isAtRight = true;
        }

        protected override void OnValueChanged(Vector2 normalizedPosition)
        {
            if (dataList.Count == 0)
                return;
            float viewportInterval = scrollRect.viewport.rect.width;
            float minViewport = -scrollRect.content.anchoredPosition.x;
            Vector2 viewportRange = new Vector2(minViewport - extendVisibleRange, minViewport + viewportInterval + extendVisibleRange);
            float contentWidth = padding.x;
            for (int i = 0; i < dataList.Count; i++)
            {
                var visibleRange = new Vector2(contentWidth, contentWidth + dataList[i].cellSize.x);
                if (visibleRange.y < viewportRange.x || visibleRange.x > viewportRange.y)
                {
                    RecycleCell(i);
                }
                contentWidth += dataList[i].cellSize.x + spacing;
            }
            contentWidth = padding.x;
            for (int i = 0; i < dataList.Count; i++)
            {
                var visibleRange = new Vector2(contentWidth, contentWidth + dataList[i].cellSize.x);
                if (visibleRange.y >= viewportRange.x && visibleRange.x <= viewportRange.y)
                {
                    SetupCell(i, new Vector2(contentWidth, 0));
                    if (visibleRange.y >= viewportRange.x)
                        cellList[i].transform.SetAsLastSibling();
                    else
                        cellList[i].transform.SetAsFirstSibling();
                }
                contentWidth += dataList[i].cellSize.x + spacing;
            }
            if (scrollRect.content.sizeDelta.x > viewportInterval)
            {
                isAtLeft = viewportRange.x + extendVisibleRange <= dataList[0].cellSize.x;
                isAtRight = scrollRect.content.sizeDelta.x - viewportRange.y + extendVisibleRange <= dataList[dataList.Count - 1].cellSize.x;
            }
            else
            {
                isAtLeft = true;
                isAtRight = true;
            }
        }

        public sealed override void Refresh()
        {
            if (!IsInitialized)
            {
                Initialize();
            }
            if (scrollRect.viewport.rect.width == 0)
                StartCoroutine(DelayToRefresh());
            else
                DoRefresh();
        }

        private void DoRefresh()
        {
            float width = padding.x;
            for (int i = 0; i < dataList.Count; i++)
            {
                width += dataList[i].cellSize.x + spacing;
            }
            for (int i = 0; i < cellList.Count; i++)
            {
                RecycleCell(i);
            }
            width += padding.y;
            scrollRect.content.sizeDelta = new Vector2(width, scrollRect.content.sizeDelta.y);
            OnValueChanged(scrollRect.normalizedPosition);
            onRefresh?.Invoke();
        }

        private IEnumerator DelayToRefresh()
        {
            yield return waitEndOfFrame;
            DoRefresh();
        }

        public override void Snap(int index, float duration)
        {
            if (!IsInitialized)
                return;
            if (index >= dataList.Count)
                return;
            if (scrollRect.content.rect.width < scrollRect.viewport.rect.width)
                return;
            float width = padding.x;
            for (int i = 0; i < index; i++)
            {
                width += dataList[i].cellSize.x + spacing;
            }
            width = Mathf.Min(scrollRect.content.rect.width - scrollRect.viewport.rect.width, width);
            if (scrollRect.content.anchoredPosition.x != width)
            {
                DoSnapping(new Vector2(-width, 0), duration);
            }
        }

        public override void Remove(int index)
        {
            var removeCell = dataList[index];
            base.Remove(index);
            scrollRect.content.anchoredPosition -= new Vector2(removeCell.cellSize.x + spacing, 0);
        }
    }
}