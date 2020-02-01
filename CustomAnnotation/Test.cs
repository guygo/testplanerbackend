using System;

namespace CustomAnnotation
{
    public class Test: Attribute
    {
        private string _accessor;
        public string Accessor
        {
            get
            {
                return _accessor;
            }
        }
        public Test(string accessor)
        {
            _accessor = accessor;
        }
    }
}
