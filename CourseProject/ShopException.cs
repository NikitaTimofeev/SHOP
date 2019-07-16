using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject
{
    class ShopException : Exception
    {
        public ShopException(string message)
        : base(message)
        { }
    }

    class BagException : Exception
    {
        public BagException(string message)
        : base(message)
        { }
    }
}
