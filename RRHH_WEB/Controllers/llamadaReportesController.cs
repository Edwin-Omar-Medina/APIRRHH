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
    public class llamadaReportesController : ApiController
    {
        public string GetReporteImprimir(string fechaSolicitud, int numDocEmpleado, int tipoFormato, string tipoVacacionesoPermisos, int Remunerado, string fechaI, string horaI, string fechaF, string horaF, string Motivo, string fechaAdicion_I, string horaAdicion_I, string fechaAdicion_F, string horaAdicion_F, string tipoCertificado)
        {
            return RRHH_Datos.Clases.Class1.rpt_Formatos( fechaSolicitud, numDocEmpleado, tipoFormato,  tipoVacacionesoPermisos, Remunerado,  fechaI,  horaI,  fechaF,  horaF,  Motivo,  fechaAdicion_I,  horaAdicion_I,  fechaAdicion_F,  horaAdicion_F,  tipoCertificado);
            
        }

    }


}