using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH_Datos.Clases
{
    public class Class2
    {
        public static int validaDOC(int numDocEmpleado)
        {
            try
            {

            DataSet.DBrecursosHumanosDataSetTableAdapters.empleadoTableAdapter ad = new DataSet.DBrecursosHumanosDataSetTableAdapters.empleadoTableAdapter();
          
            int result = 0;
                //ad.InsertFormatos(fechaSolicitud, numDocEmpleado, tipoFormato, tipoVacacionesoPermisos, Remunerado, fechaI, horaI, fechaF, horaF, Motivo, fechaAdicion_I, horaAdicion_I, fechaAdicion_F, horaAdicion_F, tipoCertificado);

                //Inicio de validacion de documento
                result = (int)ad.ValidarDoc(numDocEmpleado);
                return result;
            
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
