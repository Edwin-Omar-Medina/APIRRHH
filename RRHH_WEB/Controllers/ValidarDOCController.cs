using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace RRHH_WEB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValidarDOCController : ApiController
    {
       public int GetvalidarDocumento(int numDocEmpleado)
        {
            return RRHH_Datos.Clases.Class2.validaDOC(numDocEmpleado);
        }
    }


}