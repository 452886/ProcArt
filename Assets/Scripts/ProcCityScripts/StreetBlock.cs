using UnityEngine;
using System;

class StreetBlock
{
    Rect area;
    int streetScale;
    Material streetMaterial;
    Transform transform;

    Vector2 upperLeft;
    Vector2 lowerLeft;
    Vector2 lowerRight;
    Vector2 upperRight;

    public StreetBlock(int scale, Rect area, Material material, Transform transform)
    {
        this.area = area;
        this.transform = transform;
        this.streetScale = scale;
        this.streetMaterial = material;

        upperLeft = new Vector2(area.x, area.y)  + new Vector2(transform.position.x, transform.position.z);
        lowerLeft = new Vector2(area.x, area.y + area.height) + new Vector2(transform.position.x, transform.position.z);
        lowerRight = new Vector2(area.x + area.width, area.y + area.height) + new Vector2(transform.position.x, transform.position.z);
        upperRight = new Vector2(area.x + area.width, area.y) + new Vector2(transform.position.x, transform.position.z);
    }

    public void Draw()
    {
        drawStreet(upperLeft, lowerLeft);
        drawStreet(lowerLeft, lowerRight);
        drawStreet(lowerRight, upperRight);
        drawStreet(upperRight, upperLeft);
    }

    GameObject drawStreet(Vector2 pFrom, Vector2 pTo)
    {
        GameObject street = createCube(streetMaterial);

        Vector2 differenceVec = pTo - pFrom;
        float differenceLength = differenceVec.magnitude;

        Vector3 lookVector = new Vector3(differenceVec.x, 0, differenceVec.y);
        street.transform.position = new Vector3(pFrom.x, 0, pFrom.y);
        street.transform.localScale = new Vector3(transform.localScale.x * streetScale, 0.3f, differenceLength);
        street.transform.rotation = Quaternion.LookRotation(lookVector, Vector3.up);
        street.transform.Translate(Vector3.forward * differenceLength * 0.5f, Space.Self);

        return street;
    }

    GameObject createCube(Material material)
    {
        GameObject street = GameObject.CreatePrimitive(PrimitiveType.Cube);
        UnityEngine.Object.DestroyImmediate(street.GetComponent<BoxCollider>());
        street.GetComponent<Renderer>().material = material;
        street.name = "street";

        return street;
    }
}
