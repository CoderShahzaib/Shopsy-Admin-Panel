

namespace Shopsy.Core.DTOs
{
    public class UserApiResponseDTO<T>
    {
        public bool Result { get; set; }
        public string Message { get; set; } = string.Empty;
        public UsersData<T> Data { get; set; } = default!;
    }

    public class UsersData<T>
    {
        public int totalUsers { get; set; }
        public T Users { get; set; } = default!;
    }
}
