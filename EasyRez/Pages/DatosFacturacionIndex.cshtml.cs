using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EasyRez.Models;

namespace EasyRez.Pages
{
    public class DatosFacturacionIndexModel : PageModel
    {
        DatosFacturacionDataAccessLayer datosFacturacionDataAccessLayer = new DatosFacturacionDataAccessLayer();
        public List<DatosFacturacion> lstDatosFacturacion { get; set; }
        public Paginador<DatosFacturacion> lstDatosFacturacionActual;
        public void OnGet(int tipoEntidadTributaria = -1, int pagina = 0)
        {
            lstDatosFacturacion = datosFacturacionDataAccessLayer.GetAllDatosFacturacion(tipoEntidadTributaria).ToList();
            List<DatosFacturacion> tipo = lstDatosFacturacion.GroupBy(df => df.IdEntidadTributaria).Select(gdf => gdf.First()).ToList();

            lstDatosFacturacionActual = new Paginador<DatosFacturacion>();
            lstDatosFacturacionActual.PaginaActual = pagina;
            lstDatosFacturacionActual.TotalPaginas = tipo.Count();
            lstDatosFacturacionActual.Resultado = lstDatosFacturacion.Where(df => df.IdEntidadTributaria == tipo[pagina].IdEntidadTributaria).ToList();
        }
    }
}
