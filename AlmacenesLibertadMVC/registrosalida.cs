//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlmacenesLibertadMVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class registrosalida
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public registrosalida()
        {
            this.detallesalida = new HashSet<detallesalida>();
        }
    
        public int nrosal { get; set; }
        public System.DateTime fecent { get; set; }
        public int codemp { get; set; }
        public int coddes { get; set; }
        public bool estent { get; set; }
    
        public virtual destino destino { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detallesalida> detallesalida { get; set; }
        public virtual empleado empleado { get; set; }
    }
}
