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
    
    public partial class view_log
    {
        public int Seq { get; set; }
        public int CourseSeq { get; set; }
        public int AppendixSeq { get; set; }
        public System.DateTime ViewStartTime { get; set; }
        public Nullable<System.DateTime> ViewEndTime { get; set; }
        public System.DateTime CreatDate { get; set; }
        public int CreatUser { get; set; }
        public int DeleteTag { get; set; }
        public int LectureType { get; set; }
    }
}
