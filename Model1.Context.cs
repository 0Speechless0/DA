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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ttqs_newEntities : DbContext
    {
        public ttqs_newEntities()
            : base("name=ttqs_newEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<administrativedeeds> administrativedeeds { get; set; }
        public virtual DbSet<annual_course_planning> annual_course_planning { get; set; }
        public virtual DbSet<carousel_map> carousel_map { get; set; }
        public virtual DbSet<city> city { get; set; }
        public virtual DbSet<cooperativeevent> cooperativeevent { get; set; }
        public virtual DbSet<cooperativeeventassign> cooperativeeventassign { get; set; }
        public virtual DbSet<course> course { get; set; }
        public virtual DbSet<course_appendix> course_appendix { get; set; }
        public virtual DbSet<course_designate> course_designate { get; set; }
        public virtual DbSet<course_exam> course_exam { get; set; }
        public virtual DbSet<course_question> course_question { get; set; }
        public virtual DbSet<course_signup> course_signup { get; set; }
        public virtual DbSet<course_survey1> course_survey1 { get; set; }
        public virtual DbSet<course_survey2> course_survey2 { get; set; }
        public virtual DbSet<course_survey3> course_survey3 { get; set; }
        public virtual DbSet<creditclass> creditclass { get; set; }
        public virtual DbSet<creditclassplace> creditclassplace { get; set; }
        public virtual DbSet<creditclasssignup> creditclasssignup { get; set; }
        public virtual DbSet<departmentwork> departmentwork { get; set; }
        public virtual DbSet<description_attitude> description_attitude { get; set; }
        public virtual DbSet<description_certificate> description_certificate { get; set; }
        public virtual DbSet<description_experience> description_experience { get; set; }
        public virtual DbSet<description_language> description_language { get; set; }
        public virtual DbSet<description_object> description_object { get; set; }
        public virtual DbSet<description_task> description_task { get; set; }
        public virtual DbSet<expert_certificate> expert_certificate { get; set; }
        public virtual DbSet<expert_data> expert_data { get; set; }
        public virtual DbSet<expertise> expertise { get; set; }
        public virtual DbSet<function_category> function_category { get; set; }
        public virtual DbSet<function_factor> function_factor { get; set; }
        public virtual DbSet<function_project> function_project { get; set; }
        public virtual DbSet<function_unit> function_unit { get; set; }
        public virtual DbSet<job_description> job_description { get; set; }
        public virtual DbSet<job_title> job_title { get; set; }
        public virtual DbSet<lecture_record> lecture_record { get; set; }
        public virtual DbSet<location> location { get; set; }
        public virtual DbSet<menu> menu { get; set; }
        public virtual DbSet<new_ticker> new_ticker { get; set; }
        public virtual DbSet<r_teacher_student> r_teacher_student { get; set; }
        public virtual DbSet<recommend_class> recommend_class { get; set; }
        public virtual DbSet<recommend_class_log> recommend_class_log { get; set; }
        public virtual DbSet<schoolsystem> schoolsystem { get; set; }
        public virtual DbSet<seriallist> seriallist { get; set; }
        public virtual DbSet<studentmain> studentmain { get; set; }
        public virtual DbSet<systemtype> systemtype { get; set; }
        public virtual DbSet<teachermain> teachermain { get; set; }
        public virtual DbSet<training_goal> training_goal { get; set; }
        public virtual DbSet<training_object> training_object { get; set; }
        public virtual DbSet<unit> unit { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<user_role> user_role { get; set; }
        public virtual DbSet<view_history> view_history { get; set; }
        public virtual DbSet<view_log> view_log { get; set; }
        public virtual DbSet<work_function_set> work_function_set { get; set; }
        public virtual DbSet<function_set> function_set { get; set; }
    }
}
