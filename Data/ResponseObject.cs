using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
   public class ResponseObject
   {
       public Object data;
       public ResponseObject(String data)
       {
           this.data = data;
       }
   }
}