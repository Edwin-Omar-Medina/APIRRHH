using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHH_Datos
{
    public class Class1
    {
        /*cLASE 1*/

        public string getReporte(string fechaSolicitud, int numDocEmpleado, int tipoFormato, string tipoVacacionesoPermisos, int Remunerado,  string fechaI, string horaI, string fechaF, string horaF, string Motivo, string fechaAdicion_I, string horaAdicion_I, string fechaAdicion_F, string horaAdicion_F, string tipoCertificado ) {
            DataSet.DBrecursosHumanosDataSet data = new DataSet.DBrecursosHumanosDataSet();
            DataSet.DBrecursosHumanosDataSetTableAdapters.empleadoTableAdapter ad = new DataSet.DBrecursosHumanosDataSetTableAdapters.empleadoTableAdapter();
            DataSet.DBrecursosHumanosDataSet.empleadoDataTable info = new DataSet.DBrecursosHumanosDataSet.empleadoDataTable();

            string aBase64 = "";
            int IdSolicitud = ad.FillByMaxID(info) + 1;
            //ad.InsertFormatos(fechaSolicitud, numDocEmpleado, tipoFormato, tipoVacacionesoPermisos, Remunerado, fechaI, horaI, fechaF, horaF, Motivo, fechaAdicion_I, horaAdicion_I, fechaAdicion_F, horaAdicion_F, tipoCertificado);

            switch (tipoFormato)
            {
                case 1: //PERMISOS
                    ad.InsertFormatos(fechaSolicitud, numDocEmpleado, 1, tipoVacacionesoPermisos, Remunerado, fechaI, horaI, fechaF, horaF, Motivo, "", "", "", "", "");
                    ad.FillByFormatos(info, IdSolicitud);
                    REPORTES.FormatoPermisos rpt_permisos = new REPORTES.FormatoPermisos();
                    rpt_permisos.SetDataSource(data);
                    Stream s = rpt_permisos.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    MemoryStream ms = new MemoryStream();
                    s.CopyTo(ms);
                    rpt_permisos.Dispose();
                    aBase64 = Convert.ToBase64String(ms.ToArray());
                    break;

                case 2://COMPENSATORIOS
                    ad.InsertFormatos(fechaSolicitud, numDocEmpleado, 2, "", 0, fechaI, horaI, fechaF, horaF, Motivo, fechaAdicion_I, horaAdicion_I, fechaAdicion_F, horaAdicion_F, "");
                    ad.FillByFormatos(info, IdSolicitud);
                    REPORTES.FormatoCompensatorios rpt_compensatorios = new REPORTES.FormatoCompensatorios();
                    rpt_compensatorios.SetDataSource(data);
                    Stream s2 = rpt_compensatorios.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    MemoryStream ms2 = new MemoryStream();
                    s2.CopyTo(ms2);
                    rpt_compensatorios.Dispose();
                    aBase64 = Convert.ToBase64String(ms2.ToArray());

                    break;
                case 3://VACACIONES
                    ad.InsertFormatos(fechaSolicitud, numDocEmpleado, 3, tipoVacacionesoPermisos, Remunerado, fechaI, horaI, fechaF, horaF, Motivo, "", "", "", "", "");
                    ad.FillByFormatos(info, IdSolicitud);
                    REPORTES.FormatoVacaciones rpt_vacaciones = new REPORTES.FormatoVacaciones();
                    rpt_vacaciones.SetDataSource(data);
                    Stream s3 = rpt_vacaciones.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    MemoryStream ms3 = new MemoryStream();
                    s3.CopyTo(ms3);
                    rpt_vacaciones.Dispose();
                    aBase64 = Convert.ToBase64String(ms3.ToArray());
                    break;
                case 4://CERTIFICADOS
                    ad.InsertFormatos(fechaSolicitud, numDocEmpleado, 4, "", 0, "", "", "", "", Motivo, "", "", "", "", tipoCertificado);
                    ad.FillByFormatos(info, IdSolicitud);
                    REPORTES.FormatoCertificados rpt_certificados = new REPORTES.FormatoCertificados();
                    rpt_certificados.SetDataSource(data);
                    Stream s4 = rpt_certificados.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    MemoryStream ms4 = new MemoryStream();
                    s4.CopyTo(ms4);
                    rpt_certificados.Dispose();
                    aBase64 = Convert.ToBase64String(ms4.ToArray());
                    break;

                default:
                    
                    break;
            }

        return aBase64;
        }
    }
}
