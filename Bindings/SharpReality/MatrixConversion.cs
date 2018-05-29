using System.Numerics;
using Urho.SharpReality;

namespace Urho
{
    class MatrixConversion
    {
        /// <summary>
        /// Convert a Holographic (X-right/Y-up/Z-backward, "row-major", "row vector on left") Matrix4x4 representing
        /// an affine transform to an Urho (X-right/Y-up/Z-forward, "row-major", "column vector on right") Matrix4
        /// </summary>
        /// <param name="tr">Holographic Matrix4x4</param>
        /// <returns>Urho Matrix4</returns>
        /// <remarks>
        /// Urho matrices require a transpose from "row vector on left" data to "column vector on right", then
        ///
        /// holoFromUrho is:  1  0  0  0
        ///                   0  1  0  0
        ///                   0  0 -1  0
        ///                   0  0  0  1
        ///
        /// scene transforms have Urho input, Urho output, so Holographic transforms require change of basis:
        /// urhoOut = (urhoFromHolo * holoAffine * holoFromUrho) * urhoIn
        /// See also: David Eberly "Conversion of Left-Handed Coordinates to Right - Handed Coordinates"
        /// </remarks>
        public static Matrix4 AffineTransformFromHolographic(Matrix4x4 tr)
        {
            return new Matrix4(
                tr.M11, tr.M21, -tr.M31, tr.M41,
                tr.M12, tr.M22, -tr.M32, tr.M42,
                -tr.M13, -tr.M23, tr.M33, -tr.M43,
                tr.M14, tr.M22, tr.M34, tr.M44);
        }

        /// <summary>
        /// Convert a Holographic (X-right/Y-up/Z-backward, "row-major", "row vector on left") Matrix4x4 representing
        /// a projection to an Urho (X-right/Y-up/Z-forward, "row-major", "column vector on right") Matrix4
        /// </summary>
        /// <param name="tr">Holographic Matrix4x4</param>
        /// <returns>Urho Matrix4</returns>
        /// <remarks>
        /// Projections have Urho input, clip output; assuming clip space is the same between both, projections require reflection:
        /// clipOut = (holoProjection * holoFromUrho) * urhoIn
        /// </remarks>
        public static Matrix4 ProjectionFromHolographic(Matrix4x4 prj)
        {
            return new Matrix4(
                prj.M11, prj.M21, -prj.M31, prj.M41,
                prj.M12, prj.M22, -prj.M32, prj.M42,
                prj.M13, prj.M23, -prj.M33, prj.M43,
                prj.M14, prj.M24, -prj.M34, prj.M44);
        }
    }
}
