using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator
{
    List<Rect> roadLayout;
    int scale;
    Material material;
    Transform tf;

    public RoadGenerator(List<Rect> roadLayout, int scale, Material material, Transform transform)
    {
        this.roadLayout = roadLayout;
        this.scale = scale;
        this.material = material;
        this.tf = transform;
    }
    public void DrawRoads()
    {
        foreach (Rect area in roadLayout)
        {

            StreetBlock streetBlock = new StreetBlock(scale, area, material, tf);
            streetBlock.Draw();
        }
    }
}
