using UnityEngine;
using System;
using System.Collections.Generic;

class City
{
    int width, length, districtMinSize, mainRoadScale;

    Material mainRoadMaterial;

    List<CityDistrict> cityDistricts = new List<CityDistrict>();
    BuildSettings buildSettings;

    public City(BuildSettings buildSettings)
    {
        this.width = buildSettings.cityWidth;
        this.length = buildSettings.cityLength;
        this.districtMinSize = buildSettings.districtMinSize;
        this.mainRoadScale = buildSettings.roadScale;
        this.mainRoadMaterial = buildSettings.roadMaterial;

        this.buildSettings = buildSettings;

        generateCity();
    }

    void generateCity()
    {
        GridGenerator gg = new GridGenerator(width, length, districtMinSize, mainRoadScale * 2);
        List<Rect> districtsPlanes = gg.Generate();

        RoadGenerator rg = new RoadGenerator(districtsPlanes, mainRoadScale, mainRoadMaterial, buildSettings.cityTransform);
        rg.DrawRoads();

        int count = districtsPlanes.Count;
        int randomDistrict = UnityEngine.Random.Range(0, count);

        for (int i = 0; i < districtsPlanes.Count; i++)
        {
            if (i == randomDistrict ||  i - randomDistrict == 1)
            {
                CityDistrict district = new CityDistrict(districtsPlanes[i], "entr", buildSettings);
                cityDistricts.Add(district);
            }
            else
            {
                CityDistrict district = new CityDistrict(districtsPlanes[i], "kitsch", buildSettings);
                cityDistricts.Add(district);
            }
        }
    }

    public void InitializeCity()
    {
        foreach (CityDistrict cityDistrict in cityDistricts)
        {
            cityDistrict.InitializeBuildings();
        }
    }
}


