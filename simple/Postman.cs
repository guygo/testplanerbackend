using CustomAnnotation;
using System;
using System.Collections.Generic;
using System.Text;

namespace simple
{
    public class Postman
    {
        public string Name { get; set; }
        public int numOfletters;
        public Postman()
        {
            numOfletters = 0;
        }
        [Test("deliever")]
        public string Deliever(int x)
        {
            if (numOfletters == 0)
                return "";
            numOfletters--;
            return "" + numOfletters;
        }
        public void Accept() { numOfletters++; }
        override
        public string ToString()
        {
            return string.Format("num of letters :{0} by {1}", numOfletters, Name).ToString();
        }
    }
}
