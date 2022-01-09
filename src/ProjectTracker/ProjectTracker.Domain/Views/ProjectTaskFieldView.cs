namespace ProjectTracker.Domain.Views
{
    public class ProjectTaskFieldView : IProjectTaskField
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
