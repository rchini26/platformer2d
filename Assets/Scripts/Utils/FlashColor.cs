using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
   public List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
   public Color color = Color.red;
   public float duration = 0.3f;

   private Tween _currentTween;

   void OnValidate()
   {
      RefreshSpriteList();
   }

   // Refresh the list to remove nulls and rebuild from children
   public void RefreshSpriteList()
   {
      spriteRenderers.Clear();
      foreach (var child in GetComponentsInChildren<SpriteRenderer>())
      {
         if (child != null)
            spriteRenderers.Add(child);
      }
   }

   public void Flash()
   {
      // Kill any existing tween safely
      if (_currentTween != null && _currentTween.IsActive())
      {
         _currentTween.Kill();
         foreach (var sr in spriteRenderers)
         {
            if (sr != null) sr.color = Color.white;
         }
      }

      // Clean out destroyed references before starting new tweens
      spriteRenderers.RemoveAll(sr => sr == null);

      foreach (var sprite in spriteRenderers)
      {
         if (sprite != null && sprite.gameObject.activeInHierarchy)
         {
            _currentTween = sprite.DOColor(color, duration)
               .SetLoops(2, LoopType.Yoyo);
         }
      }
   }
}
