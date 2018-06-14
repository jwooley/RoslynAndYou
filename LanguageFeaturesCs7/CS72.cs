using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeaturesCs7
{
    [TestClass]
    public class CS72
    {

        public int HasLotsOfParams(int a, int b = 2, int c = 3, int d = 4)
        {
            return a + b + c + d;
        }

        [TestMethod]
        public void CS72_NonTrailingNamedArguments()
        {
            Assert.AreEqual(10, HasLotsOfParams(1));
            Assert.AreEqual(107, HasLotsOfParams(1, c: 100));
            Assert.AreEqual(107, HasLotsOfParams(a: 1, c: 100));
            Assert.AreEqual(107, HasLotsOfParams(c: 100, a: 1));
        }


        [TestMethod]
        public void CS72_LeadingUnderscorsInDigitSeparators()
        {
            var thisDidntWorkWith70 = 0b_0001;
            Assert.AreEqual(1, thisDidntWorkWith70);
        }

        #region ReferenceSemantics
        private static double Hypotenuse(double x, double y) // Test with ref and in
        {
            var z = Math.Sqrt((x * x) + (y * y));
            return z;
        }

        [TestMethod]
        public void CS72_ReferenceSemantics_In()
        {
            var a = 3.0;
            var b = 4.0;

            Assert.AreEqual(5.0, Hypotenuse(a, b));
            Assert.AreEqual(3.0, a);
        }

        private static double p = 3.15;
        public static ref readonly double PIish => ref p;

        [TestMethod]
        public void CS72_ReferenceSemantics_refReadonly()
        {
            var p1 = CS72.PIish;                    // By val copy
            ref readonly var p2 = ref CS72.PIish;   // Readonly reference

            p1 = 3.14;                              // Changable
            //p2 = 3.14;                            // can't change

        }
        [TestMethod]
        public void CS7_ReferenceSemantics_readonlyStruct()
        {
            var c = new Coords(3, 4);
            Assert.AreEqual(0, Coords.Start.X);
            // Coords.Start.X = c.X;
        }

        readonly struct Coords
        {
            public Coords(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }
            public double X { get; }
            public double Y { get; }
            private static readonly Coords start = new Coords(0, 0);
            public static ref readonly Coords Start => ref start;
        }
        #endregion

        #region PrivateProtected
        [TestMethod]
        public void Cs72_PrivateProtected()
        {
            A instance = new B();
            Assert.AreEqual("B", instance.ValB);
            // Not exposed from base class instance.ValC 
        }

        private protected class A
        {
            public string ValB { get; set; } = "B";
        }
        private class B: A
        {
            public string ValC { get; set; } = "C";
        }
        //public class C: A
        //{
        //  Can't expose outside of private scope
        //}
    }

    // Not available outside of a class nesting
    //private protected class ExtA
    //{
    //    public string ValB { get; set; } = "B";
    //}
    #endregion
}
