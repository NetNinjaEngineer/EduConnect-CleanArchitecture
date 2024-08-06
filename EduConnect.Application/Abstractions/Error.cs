namespace EduConnect.Application.Abstractions
{
    public sealed class Error(string? errorMessage, string? code)
    {
        public string? ErrorMessage { get; set; } = errorMessage;
        public string? Code { get; set; } = code;

        public static Error None => new(null, null);
    }
}
