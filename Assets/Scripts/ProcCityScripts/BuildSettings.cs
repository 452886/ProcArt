using System;
using System.Collections.Generic;
using UnityEngine;


public class BuildSettings : MonoBehaviour
{
    public Transform cityTransform;

    public int cityWidth = 500;
    public int cityLength = 500;

    public int districtMinSize = 45;
    public int landmarkRadius = 30;

    public Material roadMaterial;
    public int roadScale = 10;

    public Material districtRoadMaterial;

    public int entrMinBuildingSize = 1;
    public int kitschMinBuildingSize = 2;

    public Material entrMaterial;
    public int entrMinBuildingHeigth = 25;
    public int entrMaxBuildingHeigth = 100;

    public Material kitschMaterial;
    public int kitschMinBuildingHeigth = 10;
    public int kitschMaxBuildingHeigth = 35;

    public Material landmarkMaterial;
    public int landmarkMinBuildingHeigth = 40;
    public int landmarkMaxBuildingHeigth = 75;
}
