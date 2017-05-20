using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions 
{
    /// <summary>
	/// Returns vector with specified y.
	/// </summary>
	/// <returns>The x.</returns>
	/// <param name="a">Input vector.</param>
	/// <param name="x">The x coordinate.</param>
	public static Vector3 WithX(this Vector3 a, float x)
    {
        return new Vector3(x, a.y, a.z);
    }

    /// <summary>
    /// Returns vector with specified y.
    /// </summary>
    /// <returns>The y.</returns>
    /// <param name="a">Input vector.</param>
    /// <param name="y">The y coordinate.</param>
    public static Vector3 WithY(this Vector3 a, float y)
	{
		return new Vector3 (a.x, y, a.z);
	}

    /// <summary>
    /// Returns vector with specified z.
    /// </summary>
    /// <returns>The y.</returns>
    /// <param name="a">Input vector.</param>
    /// <param name="z">The z coordinate.</param>
    public static Vector3 WithZ(this Vector3 a, float z)
    {
        return new Vector3(a.x, a.y, z);
    }

    public static bool IsApproximately(this float first, float second)
    {
        return second >= (first * 0.99f) && second <= (first * 1.01f);
    }
}
