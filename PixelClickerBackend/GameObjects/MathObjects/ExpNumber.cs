using System;

namespace PixelClickerBackend
{


    ///<summary>
    /// A class that can handle extremely large numbers, but only with 6 digits of precision.
    /// Numbers are represented with a significand and a magnitude. This works exactly like scientific notation.
    ///<summary>
    public class ExpNumber
    {
        public double significand;
        public int magnitude;
        private static int PRECISION_DIGITS = 5;

        public ExpNumber(double significand, int magnitude)
        {
            this.significand = significand;
            this.magnitude = magnitude;
            this.significand = Round(significand);
            ShiftSignificandIntoMagnitude();
            
        }


        public void Multiply(ExpNumber value){
            this.significand = this.significand * value.significand;
            this.magnitude = this.magnitude + value.magnitude;
            ShiftSignificandIntoMagnitude();
        }

        /// <Summary>
        /// Adds the value passed into the function to the current ExpNumber
        /// </Summary>
        public void Add(ExpNumber addition)
        {
            ExpNumber additionClone = addition.Clone();
            if (additionClone.magnitude > this.magnitude)
            {
                double tempSignificand = this.significand;
                int tempMagnitude = this.magnitude;
                this.magnitude = additionClone.magnitude;
                this.significand = additionClone.significand;
                additionClone.significand = tempSignificand;
                additionClone.magnitude = tempMagnitude;
            }
            this.significand += additionClone.significand /
                                (double)Math.Pow(10, this.magnitude - 
                                                    additionClone.magnitude);

            ShiftSignificandIntoMagnitude();
            this.significand = Round(significand);
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                ExpNumber other = (ExpNumber)obj;
                double absOtherSignificand = Math.Abs(other.significand);
                double absThisSignificand = Math.Abs(this.significand);
                
                return (absOtherSignificand <= absThisSignificand * 1.001) &&
                       (absOtherSignificand >= absThisSignificand * .999) &&
                        (this.magnitude == other.magnitude);
            }
        }

        private double Round(double value)
        {
            return Math.Round(value, PRECISION_DIGITS);
        }

        private void ShiftSignificandIntoMagnitude(){
            while (this.significand >= 10f)
            {
                this.significand /= 10.0;
                this.magnitude += 1;
            }
            while (this.significand <= -10f)
            {
                this.significand /= 10.0;
                this.magnitude += 1;
            }
            
        
        }

        public ExpNumber Clone()
        {
            return new ExpNumber(this.significand, this.magnitude);
        }

        public override string ToString(){
            return significand + "e^" + magnitude;
        }


    }
}