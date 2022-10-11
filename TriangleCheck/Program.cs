using System;
using System.Collections.Generic;



var triangleType = TriangleType.NotTriangle;
List<string> triangleSides = new List<string>();



try
{
    if(args.Length != 3)
    {
        throw new IndexOutOfRangeException();
    }
    for(int i = 0; i < 3; i++)
    {
        triangleSides.Add(args[i]);
    }
    float sideA = float.Parse(triangleSides[0]);
    float sideB = float.Parse(triangleSides[1]);
    float sideC = float.Parse(triangleSides[2]);
    if(IsValidTriangle(sideA, sideB, sideC) == true)
    {
        triangleType = TriangleType.Triangle;
    }
    else
    {
        //triangleType = TriangleType.NotTriangle;
        Console.WriteLine("NotTriangle");
        return;
    }
    if(IsEquilateralTriangle(sideA, sideB, sideC) == true)
    {
        triangleType = TriangleType.Equilateral;
    }
    if(IsIsoscelesTriangle(sideA, sideB, sideC) == true)
    {
        triangleType = TriangleType.Isosceles;
    }
    Console.WriteLine(triangleType);
}
catch(Exception)
{
    Console.WriteLine("UnknownError");
}

bool IsValidTriangle(float sideA, float sideB, float sideC)
{
    if ((sideA + sideB > sideC) && (sideA + sideC > sideB) && (sideC + sideB > sideA))
    {
        return true;
    }
    return false;
}

bool IsIsoscelesTriangle(float sideA, float sideB, float sideC)
{
    if (((sideA == sideB) && (sideA != sideC)) || ((sideA == sideC) && (sideA != sideB)) || ((sideB == sideC) && (sideB != sideA)))
    {
        return true;
    }
    return false;
}

bool IsEquilateralTriangle(float sideA, float sideB, float sideC)
{
    if((sideA == sideB) && (sideA == sideC) && ((sideA > 0) && (sideB > 0) && (sideC > 0)))
    {
        return true;
    }
    return false;
}


enum TriangleType
{
    NotTriangle,
    Triangle,
    Equilateral,
    Isosceles,
}


