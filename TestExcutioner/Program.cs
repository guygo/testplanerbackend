using simple;
using System;
using CustomAnnotation;
using System.Linq.Expressions;
using System.Linq;
using System.Reflection;

namespace TestExcutioner
{
    class Program
    {

        private  Postman _m;

        public  Program()
        {
            _m = new Postman();
            _m.Name = "yossi";
        }

        public string CallMethodByAccessor(string accessor, int i)
        {
            // this is pseudo-code, expressing what I want to be able to do.
            FindAMethodByAttribute(_m, accessor);
           
            return _m.ToString();
        }

        private void FindAMethodByAttribute(Postman m, string accessor)
        {
            var desiredMethod = m.GetType().GetMethods()
              .Where(x => x.GetCustomAttributes(typeof(Test), false).Length > 0)
              .Where(y => (y.GetCustomAttributes(typeof(Test), false).First() as Test).Accessor == accessor)
              .FirstOrDefault();
            ConstructorInfo magicConstructor = m.GetType().GetConstructor(Type.EmptyTypes);
            object magicClassObject = magicConstructor.Invoke(new object[] { });

            desiredMethod.Invoke(magicClassObject, new object[] { 100 });
            
        }

        static void Main(string[] args)
        {
            Program p=new Program();
            Console.WriteLine(p.CallMethodByAccessor("deliever", 2));
        }
    }
}
