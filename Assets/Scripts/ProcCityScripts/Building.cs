using System;
using UnityEngine;
using System.Collections.Generic;


public class Building
{
    Vector3 position;
    int width, length, heigth, roadScale;
    Material material;
    BuildSettings buildSettings;

    string style;

    public Building(Rect plane, string style, BuildSettings buildSettings, Transform transform)
    {
        this.position = new Vector3(plane.position.x, 0, plane.position.y) + transform.position;
        this.width = (int)(plane.width - buildSettings.roadScale * buildSettings.roadScale / (buildSettings.roadScale + buildSettings.roadScale * 0.1f));
        this.length = (int)(plane.height - buildSettings.roadScale * buildSettings.roadScale / (buildSettings.roadScale + buildSettings.roadScale * 0.1f));
        this.style = style;
        this.roadScale = buildSettings.roadScale;

        setStyle(style, buildSettings);
    }


    public void InitializeBuilding()
    {
        GameObject stock = createStock();
        Transform tf = stock.transform;
        tf.localScale = new Vector3(tf.localScale.x * width, tf.localScale.y * heigth, tf.localScale.z * length);
        tf.position = position + new Vector3(width * 0.5f + roadScale * 0.5f, heigth * 0.5f, length * 0.5f + roadScale * 0.5f);
    }

    private GameObject createStock()
    {
        GameObject stock = GameObject.CreatePrimitive(PrimitiveType.Cube);
        UnityEngine.Object.DestroyImmediate(stock.GetComponent<BoxCollider>());
        stock.name = "building";
        stock.GetComponent<Renderer>().material = material;

        return stock;
    }

    public void SetHeigthRange(int min, int max)
    {
        heigth = UnityEngine.Random.Range(min, max);
    }

    private void setStyle(string style, BuildSettings buildSettings)
    {
        switch (style)
        {
            case "kitsch":
                SetHeigthRange(buildSettings.kitschMinBuildingHeigth, buildSettings.kitschMaxBuildingHeigth);
                material = buildSettings.kitschMaterial;
                break;

            case "entr":
                SetHeigthRange(buildSettings.entrMinBuildingHeigth, buildSettings.entrMaxBuildingHeigth);
                material = buildSettings.entrMaterial;
                break;

            case "landmark":
                SetHeigthRange(buildSettings.landmarkMinBuildingHeigth, buildSettings.landmarkMaxBuildingHeigth);
                material = buildSettings.landmarkMaterial;
                break;

            default:
                this.heigth = UnityEngine.Random.Range(buildSettings.kitschMinBuildingHeigth, buildSettings.kitschMaxBuildingHeigth);
                material = buildSettings.kitschMaterial;
                break;
        }
    }
}
