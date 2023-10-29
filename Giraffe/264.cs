using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giraffe
{
    public sealed class Employee
    {
        private String m_Name;
        private Int32 m_Age;

        public String GetName()
        {
            return (m_Name);
        }

        public void SetName(String value)
        { 
            m_Name = value;
        }

        public Int32 GetAge()
        {
            return (m_Age);
        }

        public void SetAge(Int32 value)
        {
            if(value < 0)
                throw new ArgumentOutOfRangeException("value", value.ToString(), "The value must be greater than or equal to 0");
            m_Age = value;
        }
    }
}
