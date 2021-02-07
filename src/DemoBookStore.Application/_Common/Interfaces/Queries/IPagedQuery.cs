namespace DemoBookStore.Application.Common.Interfaces.Queries
{
    public interface IPagedQuery
    {
        int Offset { get; }
        ushort Limit { get; }
    }
}
