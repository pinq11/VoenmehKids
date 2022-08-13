using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WayPoint : MonoBehaviour
{
    public RawImage img;
    public RawImage imgFin;
    public Transform target;
    public Transform targetFinale;
    private bool end = false;
    private void Update()
    {
        float minx = img.GetPixelAdjustedRect().width / 2;
        float maxx = Screen.width - minx;

        float miny = img.GetPixelAdjustedRect().height / 2;
        float maxy = Screen.width - miny;
        Vector2 pos = Camera.main.WorldToScreenPoint(target.position);
        pos.x = Mathf.Clamp(pos.x, minx, maxx);
        pos.y = Mathf.Clamp(pos.y, miny, maxy);
        img.transform.position = pos;
        if (end)
        {
            Vector2 finpas = Camera.main.WorldToScreenPoint(targetFinale.position);
            finpas.x = Mathf.Clamp(pos.x, minx, maxx);
            finpas.y = Mathf.Clamp(pos.y, miny, maxy);
            imgFin.transform.position = finpas;
        }
    }
    public void chagnepos(Transform newTarget)
    {
        target = newTarget;
    }
    public void Finale()
    {
        end = true;
    }
}
