//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PM_01_519_Korshunova
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            this.Activity = new HashSet<Activity>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Days { get; set; }
        public Nullable<int> ID_City { get; set; }
        public Nullable<int> ID_Organizers { get; set; }
        public Nullable<int> ID_Participants { get; set; }
        public string Photo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity { get; set; }
        public virtual City City { get; set; }
        public virtual Organizers Organizers { get; set; }
        public virtual Participants Participants { get; set; }
    }
}
