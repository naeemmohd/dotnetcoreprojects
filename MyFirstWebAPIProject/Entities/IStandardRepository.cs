namespace MyFirstWebAPIProject.Entities
{
    public interface IStandardRepository
    {
        
        List<Standard> GetStandards();
        Standard? GetStandardById(int id);
    }
}