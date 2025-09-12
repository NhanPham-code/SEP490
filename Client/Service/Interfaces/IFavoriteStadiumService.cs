using DTOs.FavoriteStadiumDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    /// <summary>
    /// Interface định nghĩa các nghiệp vụ liên quan đến Favorite Stadium.
    /// </summary>
    public interface IFavoriteStadiumService
    {
        /// <summary>
        /// Lấy danh sách các sân vận động yêu thích của một người dùng cụ thể.
        /// </summary>
        /// <returns>Danh sách các Favorite DTO.</returns>
        Task<IEnumerable<FavoriteDTO>> GetMyFavoritesAsync(string accessToken);

        /// <summary>
        /// Thêm một sân vận động vào danh sách yêu thích.
        /// </summary>
        /// <param name="createFavoriteDTO">Dữ liệu để tạo mới một Favorite.</param>
        /// <returns>Favorite DTO vừa được tạo.</returns>
        Task<FavoriteDTO> AddFavoriteAsync(CreateFavoriteDTO createFavoriteDTO, string accessToken);

        /// <summary>
        /// Xóa một sân vận động khỏi danh sách yêu thích.
        /// </summary>
        /// <param name="favoriteId">ID của Favorite cần xóa.</param>
        /// <returns>Trả về true nếu xóa thành công, false nếu không tìm thấy.</returns>
        Task<bool> DeleteFavoriteAsync(int favoriteId, string accessToken);

        /// <summary>
        /// Kiểm tra xem một người dùng đã yêu thích một sân vận động hay chưa.
        /// </summary>
        /// <param name="userId">ID của người dùng.</param>
        /// <param name="stadiumId">ID của sân vận động.</param>
        /// <returns>True nếu đã tồn tại, ngược lại là false.</returns>
        Task<bool> IsFavoriteExistsAsync(int userId, int stadiumId, string accessToken);
    }
}
