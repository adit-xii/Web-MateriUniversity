//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _04.Materi.University.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_m_dosen
    {
        public long id_dosen_pk { get; set; }
        public string kode_dosen { get; set; }
        public string nama_dosen { get; set; }
        public int id_jurusan_fk { get; set; }
        public int id_type_dosen_fk { get; set; }
        public bool is_active { get; set; }
        public string created_by { get; set; }
        public System.DateTime created_date { get; set; }
        public string updated_by { get; set; }
        public System.DateTime updated_date { get; set; }
    }
}