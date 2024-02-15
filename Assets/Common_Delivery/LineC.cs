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

    public LineC(Vector3C pointA, Vector3C pointB):this()
    {
        this.origin = pointA;
        this.direction = pointB - pointA;
    }
    #endregion

    #region OPERATORS
    #endregion

    #region METHODS
    #endregion

    #region FUNCTIONS
    #endregion

}