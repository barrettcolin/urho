using System.Numerics;
using Urho.SharpReality;

namespace Urho
{
    class MatrixConversion
    {
        public static Matrix4 AffineTransformFromDirectX(Matrix4x4 tr)
        {
            return new Matrix4(
                tr.M11, tr.M12, -tr.M13, tr.M14, 
                tr.M21, tr.M22, -tr.M23, tr.M24,
                -tr.M31, -tr.M32, tr.M33, -tr.M34, 
                tr.M41, tr.M42, tr.M43, tr.M44);
        }

        public static Matrix4 ProjectionFromDirectX(Matrix4x4 prj)
        {
            return new Matrix4(
                prj.M11, prj.M12, -prj.M13, prj.M14,
                prj.M21, prj.M22, -prj.M23, prj.M24,
                prj.M31, prj.M32, -prj.M33, prj.M34,
                prj.M41, prj.M42, -prj.M43, prj.M44);
        }
    }
}
