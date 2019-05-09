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
            ShiftSignificandIntoMagnitude();
            this.significand = Round(this.significand);
        }

        /// <summary>
        ///  Raises this number to the power of the passed value
        ///  Node that passing in values
        /// </summary>
        public void Pow(int exponent)
        { 
            ExpNumber valueCollector = new ExpNumber(1, 0);
            ExpNumber powChunck = null;
            // Break into chucks to let Math.Pow do the most work it can. 
            // Chunks have to be < 308 to avoid overflow
            while (exponent / 250 > 0){
                if (powChunck == null){
                    powChunck = this.Clone();
                    powChunck.Pow(249);
                }
                valueCollector.Multiply(powChunck);
                exponent -= 249;
            }
            this.significand = Math.Pow(this.significand, exponent);
            this.magnitude = this.magnitude * exponent;
            ShiftSignificandIntoMagnitude();
            this.Multiply(valueCollector);
        }

        public void Multiply(ExpNumber value){
            this.significand = this.significand * value.significand;
            this.magnitude = this.magnitude + value.magnitude;
            ShiftSignificandIntoMagnitude();
        }

        /// <summary>
        /// Divides the current ExpNumber by the passed in value. 
        /// </summary>
        public void Divide(ExpNumber divisor){
            this.significand = this.significand / divisor.significand;
            this.magnitude = this.magnitude - divisor.magnitude;
            ShiftSignificandIntoMagnitude();
        }

        /// <summary>
        /// Subtracts the passed in value from the current ExpNumber
        /// </summary>
        public void Subtract(ExpNumber value){
            ExpNumber subtractValue = value.Clone();
            if (subtractValue.magnitude > this.magnitude)
            {
                double tempSignificand = this.significand;
                int tempMagnitude = this.magnitude;
                this.magnitude = subtractValue.magnitude;
                this.significand = subtractValue.significand;
                subtractValue.significand = tempSignificand;
                subtractValue.magnitude = tempMagnitude;
            }
            this.significand -= subtractValue.significand /
                                (double)Math.Pow(10, this.magnitude - 
                                                    subtractValue.magnitude);

            ShiftSignificandIntoMagnitude();
            this.significand = Round(significand);
        }



        /// <Summary>
        /// Adds the value passed into the function to the current ExpNumber
        /// </Summary>
        public void Add(ExpNumber addition)
        {
            ExpNumber subtractValue = addition.Clone();
            if (subtractValue.magnitude > this.magnitude)
            {
                double tempSignificand = this.significand;
                int tempMagnitude = this.magnitude;
                this.magnitude = subtractValue.magnitude;
                this.significand = subtractValue.significand;
                subtractValue.significand = tempSignificand;
                subtractValue.magnitude = tempMagnitude;
            }
            this.significand += subtractValue.significand /
                                (double)Math.Pow(10, this.magnitude - 
                                                    subtractValue.magnitude);

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
            if (this.significand == 0){
                this.magnitude = 0;
                return;
            }
            while (Math.Abs(this.significand) >= 10f)
            {
                this.significand /= 10.0;
                this.magnitude += 1;
            }

            while (Math.Abs(this.significand) < 1f && Math.Abs(this.significand) >= 0)
            {
                this.significand *= 10.0;
                this.magnitude -= 1;
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