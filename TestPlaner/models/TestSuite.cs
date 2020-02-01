using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestPlaner.models
{
    public class TestSuite
    {
        public TestSuite()
        {
            TestCases = new List<TestCase>();
        }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual IList<TestCase> TestCases{ get; set;}
       
    }
}
