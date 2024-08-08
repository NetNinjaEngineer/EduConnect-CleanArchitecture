namespace EduConnect.Domain.Commons;
public interface ILocalizableStudent : ILocalizable
{
    public string? FirstNameAr { get; set; }
    public string? LastNameAr { get; set; }
    public string? AddressAr { get; set; }
}
