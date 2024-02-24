using System;

[System.Serializable]
public struct PlaneC
{
    #region FIELDS
    public Vector3C position;
    public Vector3C normal;
    #endregion

    #region PROPIERTIES

    public static PlaneC right { get { return new PlaneC(new Vector3C(1, 0, 0), new Vector3C(1, 0, 0)); } } 
    public static PlaneC up { get { return new PlaneC(new Vector3C(0, 1, 0), new Vector3C(1, 0, 0)); } }
    public static PlaneC forward { get { return new PlaneC(new Vector3C(0, 0, 1), new Vector3C(1, 0, 0)); } }
    #endregion

    #region CONSTRUCTORS
    public PlaneC(Vector3C position, Vector3C normal)
    {
        this.position = position;
        this.normal = normal;
    }


    public PlaneC(Vector3C pointA, Vector3C pointB, Vector3C pointC)
    {
        Vector3C AB = pointB - pointA;
        Vector3C AC = pointC - pointA;
        Vector3C cross = Vector3C.Cross(AB,AC);

        
      float D = -(cross.x * pointA.x + cross.y * pointA.y + cross.z * pointA.z);


        float positionX = ((cross.y * pointA.y) * 0 + (cross.z * pointA.z) * 0 + D) / (cross.x * pointA.x);
        float positionY = ((cross.x * pointA.x) * 0 + (cross.z * pointA.z) * 0 + D) / (cross.y * pointA.y);
        float positionZ = ((cross.x * pointA.x) * 0 + (cross.y * pointA.y) * 0 + D) / (cross.z * pointA.z);



        this.position = new Vector3C(positionX, positionY, positionZ);
        this.normal = cross;
    }



    public PlaneC(float A, float B, float C, float D)
    {
        float positionX = (B*0+ C*0 + D) / A;
        float positionY = (A*0+ C*0 + D) / B;
        float positionZ = (A*0+ B*0 + D) / C;

        
        this.position = new Vector3C(positionX, positionY, positionZ);
        this.normal = new Vector3C(A,B,C);
    }


    #endregion

    #region OPERATORS
    public static bool operator ==(PlaneC a, PlaneC b)
    {
        if (a.position == b.position)
        {
            if (a.normal == b.normal)
            {

                return true;


            }
            else
                return false;


        }
        else
            return false;
    }

    public static bool operator !=(PlaneC a, PlaneC b)
    {
        if (a.position == b.position)
        {
            if (a.normal == b.normal)
            {

                return false;


            }
            else
                return true;


        }
        else
            return true;
    }
    #endregion

    #region METHODS
    public void ToEquation(PlaneC plano) 
    {
        float D = -(plano.normal.x * plano.position.x + plano.normal.y * plano.position.y + plano.normal.z * plano.position.z);

        float A = plano.normal.x * plano.position.x;
        float B = plano.normal.y * plano.position.y;
        float c = plano.normal.z * plano.position.z;

    }


    public Vector3C NearestPoint(PlaneC planoA, Vector3C punto)
    {
        float D = -(planoA.normal.x * planoA.position.x + planoA.normal.y * planoA.position.y + planoA.normal.z * planoA.position.z);
        float distance = Math.Abs((planoA.position.x * punto.x + planoA.position.y * punto.y + planoA.position.z * punto.z + D)
            / (float)Math.Sqrt(planoA.position.x * planoA.position.x + planoA.position.y * planoA.position.y + planoA.position.z * planoA.position.z));

        Vector3C closestPoint = new Vector3C((punto.x - planoA.position.x * distance), (punto.y - planoA.position.y * distance), (punto.z - planoA.position.z * distance));

        return closestPoint;
    }



    public LineC Intersection(PlaneC planoA, PlaneC planoB)
    {
        Vector3C cross = Vector3C.Cross(planoA.normal, planoB.normal);

        float DA = -(planoA.normal.x * planoA.position.x + planoA.normal.y * planoA.position.y + planoA.normal.z * planoA.position.z);
        float DB = -(planoB.normal.x * planoB.position.x + planoB.normal.y * planoB.position.y + planoB.normal.z * planoB.position.z);
        float denominator = planoA.position.x * planoB.position.y - planoA.position.y * planoB.position.x;
        Vector3C origin = new Vector3C((planoA.position.y * DB - planoB.position.y * DA)/ denominator, (planoB.position.x * DA - planoA.position.x * DB) / denominator,0);

        return new LineC(origin,cross);
    }


    public override bool Equals(object obj) //he copiado bool pero no deberia serlo?
    {
        if (obj is PlaneC)
        {
            PlaneC other = (PlaneC)obj;
            return other == this;
        }
        return false;//npi
    }
    #endregion

    #region FUNCTIONS
    #endregion

}