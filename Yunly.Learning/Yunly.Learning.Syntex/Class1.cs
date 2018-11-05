using System;

namespace Yunly.Learning.Syntex
{
    public class baseClass
    {
        public string publicValue;

        internal string internalValue;

        private string privateValue;
        protected string protectedValue;

        internal protected string internalProtectedValue;

        //supported from C# 7.2 only accessiable by the dervied class within the assembly
        private protected string privateProtectedValue;

    }


    public class newClass
    {
        public void testModifier()
        {
            baseClass baseClass = new baseClass();
            DerivedClass derivedClass = new DerivedClass();



            baseClass.publicValue = "OK";
            baseClass.internalProtectedValue = "OK";
            baseClass.internalValue = "OK";

            

            derivedClass.publicValue = "OK";
            derivedClass.internalProtectedValue = "OK";
            derivedClass.internalValue = "OK";

            
        }

    }

    public class DerivedClass: baseClass
    {
        public void testModifier()
        {
            base.publicValue = "OK";
            base.internalValue = "OK"; ;
            base.protectedValue = "OK"; ;
            base.internalProtectedValue = "OK"; ;
            base.privateProtectedValue = "OK";
        }
    }


}
