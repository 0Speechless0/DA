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
    
    public partial class annual_course_planning
    {
        public int Seq { get; set; }
        public int FunctionCategory { get; set; }
        public string CourseName { get; set; }
        public int TackCourseType { get; set; }
        public int TrainingGoal { get; set; }
        public string OtherTrainingGoal { get; set; }
        public string Memo { get; set; }
        public int Year { get; set; }
        public int UnitSeq { get; set; }
        public int CourseHours { get; set; }
        public int TrainingObject { get; set; }
        public string OtherTrainingObject { get; set; }
        public int TrainingNumbers { get; set; }
        public int EstimatedExpenses { get; set; }
        public string EstimatedExpensesMemo { get; set; }
        public int EstimatedStartMonth { get; set; }
        public int SubmitReview { get; set; }
        public System.DateTime CreatDate { get; set; }
        public int CreatUser { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<int> ModifyUser { get; set; }
        public int DeleteTag { get; set; }
    
        public virtual function_category function_category { get; set; }
        public virtual training_goal training_goal { get; set; }
        public virtual training_object training_object { get; set; }
        public virtual unit unit { get; set; }
    }
}
