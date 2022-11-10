using Assets.Scripts.Metanoia.Data;
using System;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Utils
{
    public static class DataExtensions
    {
        public static Vector3Data AsVectorData(this Vector3 vector) =>
            new Vector3Data(vector.x, vector.y, vector.z);

        public static Vector3 AsUnityVector(this Vector3Data vector) =>
            new Vector3(vector.X, vector.Y, vector.Z);

        public static Vector3 AddY(this Vector3 vector, float y)
        {
            vector.y += y;
            return vector;
        }

        public static Vector3 Multiply(this Vector3 vector, Vector3 b)
        {
            vector.x *= b.x;
            vector.y *= b.y;
            vector.z *= b.z;
            return vector;
        }

        public static Vector3 Abs(this Vector3 vector)
        {
            vector.x = Math.Abs(vector.x);
            vector.y = Math.Abs(vector.y);
            vector.z = Math.Abs(vector.z);
            return vector;
        }

        public static T ToDeserialized<T>(this string json) =>
            JsonUtility.FromJson<T>(json);

        public static string ToJson(this object obj) =>
            JsonUtility.ToJson(obj);
    }
}
