//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DA
{
    using System;
    using System.Collections.Generic;
    
    public partial class course_signup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public course_signup()
        {
            this.course_survey1 = new HashSet<course_survey1>();
            this.course_survey2 = new HashSet<course_survey2>();
            this.course_survey3 = new HashSet<course_survey3>();
        }
    
        public int Seq { get; set; }
        public int CourseSeq { get; set; }
        public int SignUpUser { get; set; }
        public Nullable<int> IsDesignate { get; set; }
        public int IsSignedIn { get; set; }
        public Nullable<System.DateTime> IsSignInTime { get; set; }
        public Nullable<int> IsSignedOut { get; set; }
        public Nullable<System.DateTime> IsSignOutTime { get; set; }
        public string Memo { get; set; }
        public System.DateTime CreatDate { get; set; }
        public int CreatUser { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<int> ModifyUser { get; set; }
        public Nullable<int> HasExam { get; set; }
    
        public virtual course course { get; set; }
        public virtual user user { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<course_survey1> course_survey1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<course_survey2> course_survey2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<course_survey3> course_survey3 { get; set; }
    }
}
