using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Infrastructure;

namespace WebApi.Helper
{
    public class LinkedListHelper
    {
        public int? FifithElement()
        {
            LinkedList list = new LinkedList();
            list.Append(2);
            list.Append(3);
            list.Append(4);
            list.Append(5);
            list.Append(6);
            list.Append(7);
            list.Append(8);
            list.Append(9);
            list.Append(10);
            list.Append(11);

            var fifthElement = list.GetElementAt(5);

            return fifthElement;
        }
    }
}