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
        private NameValueCollection _whereQueries;
        private readonly IModelFactory _modelFactory;

        private BoardGameService(
            IApiProvider apiProvider,
            IModelFactory modelFactory)
        {
            _apiProvider = apiProvider;
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

        public static IBoardGameService Create(
            IApiProvider apiProvider,
            IModelFactory modelFactory)
        {
            return new BoardGameService(apiProvider, modelFactory);
        }

        /// <inheritdocs />
        public async Task<Exceptional<IList<BoardGameSearch>>> SearchAsync()
        {
            try
            {
                var url = _apiProvider.BuildUri(ApiEndPoint.Search, _whereQueries);
                var rootList = await _apiProvider
                    .CallWebServiceGetAsync<BoardGameListDto>(url)
                    .ConfigureAwait(false);

                var result = rootList?.BoardGames
                    .Select(x => _modelFactory.CreateBoardGameSearch(x))
                    .ToList();

                return Exceptional<IList<BoardGameSearch>>.Success(result);
            }
            catch (Exception ex)
            {
                return Exceptional<IList<BoardGameSearch>>.Failure(ex);
            }
        }

        /// <inheritdocs />
        public async Task<Exceptional<IList<BoardGame>>> FindAsync(IList<string> ids)
        {
            try
            {
                var url = _apiProvider.BuildUri(ApiEndPoint.BoardGame, string.Join(",", ids));
                var rootList = await _apiProvider
                    .CallWebServiceGetAsync<BoardGameListDto>(url)
                    .ConfigureAwait(false);

                var result = rootList?.BoardGames
                    .Select(x => _modelFactory.CreateBoardGame(x))
                    .ToList();

                return Exceptional<IList<BoardGame>>.Success(result);
            }
            catch (Exception ex)
            {
                return Exceptional<IList<BoardGame>>.Failure(ex);
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
    }
}