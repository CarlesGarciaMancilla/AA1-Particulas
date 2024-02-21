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




        this.position = new Vector3C();
        this.normal = cross;
    }

    public PlaneC(float A, float B, float C, float D)
    {
        float positionX = (B*0+ C*0 + D) / A;
        float positionY = (A*0+ C*0 + D) / B;
        float positionZ = (A*0+ B*0 + D) / C;

        
        this.position = new Vector3C(positionX, positionY, positionZ);
        this.normal = new Vector3C();
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
      


    }

    public void Intersection(PlaneC planoA, PlaneC planoB)
    {



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