//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskTrackingApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FinalComment
    {
        public long FinalCommentID { get; set; }
        public string Screen { get; set; }
        public string TaskDescription { get; set; }
        public Nullable<long> AdminUserID { get; set; }
        public Nullable<long> UserID { get; set; }
        public System.DateTime DateOfFinalComment { get; set; }
        public long ProjectID { get; set; }
    
        public virtual Project Project { get; set; }
    }
}
