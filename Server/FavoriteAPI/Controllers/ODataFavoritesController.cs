using AutoMapper;
using FavoriteAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteAPI.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ODataFavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;
        private readonly IMapper _mapper;

        public ODataFavoritesController(IFavoriteService favoriteService, IMapper mapper)
        {
            _favoriteService = favoriteService ?? throw new ArgumentNullException(nameof(favoriteService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // /odata/ODataFavorites
        public IQueryable<Model.Favorite> Get()
        {
            // Trả về IQueryable<Favorite> trực tiếp. OData sẽ xử lý các tùy chọn truy vấn.
            return _favoriteService.GetFavorites();
        }
    }
}
