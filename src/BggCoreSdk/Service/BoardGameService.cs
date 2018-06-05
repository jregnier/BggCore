using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BggCoreSdk.Core;
using BggCoreSdk.Dto;
using BggCoreSdk.Model;

namespace BggCoreSdk.Service
{
    /// < inheritdoc />
    public class BoardGameService : IBoardGameService
    {
        private readonly IApiProvider _apiProvider;
        private readonly ApiEndPoint _endPoint;
        private NameValueCollection _whereQueries;
        private readonly IModelFactory _modelFactory;

        private BoardGameService(
            IApiProvider apiProvider,
            IModelFactory modelFactory)
        {
            _apiProvider = apiProvider;
            _endPoint = ApiEndPoint.BoardGame;
            _modelFactory = modelFactory;

            _whereQueries = new NameValueCollection();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BoardGameService" /> class.
        /// </summary>
        /// <returns>A board game service object.</returns>
        public static IBoardGameService Create()
        {
            var adapter = new BggApiServiceAdapter();
            var provider = new ApiProvider(adapter);
            var modelFactory = new ModelFactory();

            return new BoardGameService(provider, modelFactory);
        }

        /// <inheritdocs />
        public async Task<Exceptional<IList<BoardGameSearch>>> SearchAsync()
        {
            try
            {
                var url = _apiProvider.BuildUri(_endPoint, _whereQueries);
                var rootList = await _apiProvider
                    .CallWebServiceGetAsync<BoardGameSearchListDto>(url)
                    .ConfigureAwait(false);

                return Exceptional<IList<BoardGameSearch>>.Success(MapBoardGameSearch(rootList));
            }
            catch (Exception ex)
            {
                return Exceptional<IList<BoardGameSearch>>.Failure(ex);
            }
        }

        /// <inheritdocs />
        public IBoardGameService Where<U>(Expression<Func<BoardGameSearchQueryParameters, U>> property, U value)
        {
            if (property == null)
            {
                throw new ArgumentNullException("property");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var expression = property.Body as MemberExpression;
            var queryName = _apiProvider.GetQueryPropertyName<BoardGameSearchQueryParameters>(expression.Member.Name);

            _whereQueries[queryName] = Convert.ToString(value);

            return this;
        }

        /// <summary>
        /// Convert's the board game Dto to a model.
        /// </summary>
        /// <param name="list">The list of Dto object.</param>
        /// <returns>A list of models.</returns>
        private IList<BoardGameSearch> MapBoardGameSearch(BoardGameSearchListDto list)
        {
            if (list == null)
            {
                return new List<BoardGameSearch>();
            }

            return list.BoardGames
                .Select(x => _modelFactory.Create(x))
                .ToList();
        }
    }
}