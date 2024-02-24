using System;

[System.Serializable]
public struct LineC
{
    #region FIELDS
    public Vector3C origin;
    public Vector3C direction;
    #endregion

    #region PROPIERTIES
    #endregion

    #region CONSTRUCTORS
    public LineC(Vector3C origin, Vector3C direction)
    {
        this.origin = origin;
        this.direction = direction;
    }

    //public LineC(Vector3C pointA, Vector3C pointB):this()
    //{
    //    this.origin = pointA;
    //    this.direction = +(pointB - pointA);
    //}
    #endregion

    #region OPERATORS
    public static bool operator ==(LineC a, LineC b)
    {
        if (a.origin == b.origin)
        {
            if (a.direction == b.direction)
            {
               
                    return true;
                
                
            }
            else
                return false;


        }
        else
            return false;
    }

    public static bool operator !=(LineC a, LineC b)
    {
        if (a.origin == b.origin)
        {
            if (a.direction == b.direction)
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
    public Vector3C NearestToPoint(LineC line, Vector3C point) 
    {
        Vector3C lineP = new Vector3C(line.direction.x * point.x, line.direction.y * point.y, line.direction.z * point.z);
        float d = lineP.x + lineP.y + lineP.z;
        float x = (d / (line.direction.x + line.direction.y + line.direction.z));

        return new Vector3C(line.direction.x * x, line.direction.y * x, line.direction.z * x);
    }

    public Vector3C NearestToLine(LineC lineA, LineC lineB)
    {

        return new Vector3C();
    }
    #endregion

    #region FUNCTIONS
    #endregion

}