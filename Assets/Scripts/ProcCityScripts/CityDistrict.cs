using System;
using UnityEngine;
using System.Collections.Generic;

class CityDistrict
{
    int width, length, roadScale, minBuildingSize;
    string style;
    Material roadMaterial;
    Transform transform;
    BuildSettings buildSettings;

    List<Building> buildings = new List<Building>();

    public CityDistrict(Rect plane, string style, BuildSettings buildSettings)
    {
        this.width = (int)plane.width;
        this.length = (int)plane.height;
        this.roadScale = buildSettings.roadScale;
        this.style = style;
        this.transform = buildSettings.transform;
        this.transform.position = new Vector3(plane.position.x, 0, plane.position.y);
        this.roadMaterial = buildSettings.districtRoadMaterial;

        this.buildSettings = buildSettings;

        setStyle(style);
        GenerateBuildings();
    }

    //------------------------------------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------------------------------------

    public void GenerateBuildings()
    {
        GridGenerator gg = new GridGenerator(width, length, minBuildingSize, roadScale);
        List<Rect> buildingPlanes = gg.Generate();

        RoadGenerator rg = new RoadGenerator(buildingPlanes, roadScale, roadMaterial, transform);
        rg.DrawRoads();

        int randomBuilding = UnityEngine.Random.Range(0, buildingPlanes.Count);

        for (int i = 0; i < buildingPlanes.Count; i ++)
        {
            if (i == randomBuilding)
            {
                Building landmark = new Building(buildingPlanes[i], "landmark", buildSettings, transform);
                buildings.Add(landmark);
            }
            else if (Vector2.Distance(buildingPlanes[i].center, buildingPlanes[randomBuilding].center) < buildSettings.landmarkRadius)
            {
                Building subLandmark = new Building(buildingPlanes[i], style, buildSettings, transform);
                int minHeigth = (buildSettings.landmarkMinBuildingHeigth + buildSettings.kitschMinBuildingHeigth) / 2;
                int maxHeigth = (buildSettings.landmarkMaxBuildingHeigth + buildSettings.kitschMaxBuildingHeigth) / 2;

                subLandmark.SetHeigthRange(minHeigth, maxHeigth);
                buildings.Add(subLandmark);
            }else
            {
                Building building = new Building(buildingPlanes[i], style, buildSettings, transform);
                buildings.Add(building);
            }
        }
    }
    //------------------------------------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------------------------------------

    public void InitializeBuildings()
    {
        foreach (Building building in buildings)
        {
            building.InitializeBuilding();
        }
    }

    void setStyle(string style)
    {
        switch (style)
        {
            case "entr":
                minBuildingSize = buildSettings.entrMinBuildingSize;
                break;

            case "kitsch":
                minBuildingSize = buildSettings.kitschMinBuildingSize;
                break;

            default:
                minBuildingSize = buildSettings.kitschMinBuildingSize;
                break;
        }
    }
}
