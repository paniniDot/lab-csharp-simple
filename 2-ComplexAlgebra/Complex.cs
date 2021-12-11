using System;
using System.Collections.Immutable;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        public double Imaginary { get; }
        public double Real { get; }
        
        public Complex(double real, double imaginary)
        {
            Imaginary = imaginary;
            Real = real;
        }
        
        public double Modulus => Math.Sqrt((Imaginary * Imaginary) + (Real * Real));

        public double Phase => Math.Atan2(Imaginary, Real);

        public Complex Conjugate => new Complex(Real, -Imaginary);

        public Complex Plus(Complex num) => new Complex(Real + num.Real, Imaginary + num.Imaginary);

        public Complex Minus(Complex num) => Plus(new Complex(-num.Real, -num.Imaginary));

        public override string ToString()
        {
            if (Imaginary == 0.0) return Real.ToString();
            var imAbs = Math.Abs(Imaginary);
            var imValue = imAbs == 1.0 ? "" : imAbs.ToString();
            string sign;
            if (Real == 0d)
            {
                sign = Imaginary > 0 ? "" : "-";
                return sign + "i" + imValue;
            }

            sign = Imaginary > 0 ? "+" : "-";
            return $"{Real} {sign} i{imValue}";
        }
        public bool Equals(Complex num) => Real.Equals(num.Real) && Imaginary.Equals(num.Imaginary);

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (this == obj)
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals(obj as Complex);
        }

        public override int GetHashCode() => HashCode.Combine(Real, Imaginary);
    }
}