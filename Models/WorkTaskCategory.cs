namespace TaskApi.Models;

public class WorkTaskCategory
{
    public Guid WorkTaskId { get; set; }
    public virtual WorkTask WorkTask { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}