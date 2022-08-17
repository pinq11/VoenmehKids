using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WayPoint : MonoBehaviour
{
    public Image img;
    public Transform target;
    private void Update()
    {
        float minx = img.GetPixelAdjustedRect().width / 2;
        float maxx = Screen.width - minx;

        float miny = img.GetPixelAdjustedRect().height / 2;
        float maxy = Screen.height - miny;
        Vector2 pos = Camera.main.WorldToScreenPoint(target.position);
        pos.x = Mathf.Clamp(pos.x, minx, maxx);
        pos.y = Mathf.Clamp(pos.y, miny, maxy);
        if (Vector3.Dot((target.position - transform.position), transform.forward) < 0)
        {
            if (pos.x < Screen.width / 2)
            {
                pos.x = maxx;
            }
            else
            {
                pos.x = minx;
            }
        }
        img.transform.position = pos;
        
    }
    public void chagnepos(Transform newTarget)
    {
        target = newTarget;
    }
}
