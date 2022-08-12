using AlloyTraining.Models.Pages;
using EPiServer.Core;
using EPiServer.Search;
using EPiServer.Search.Queries.Lucene;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyTraining.Business.ExtensionMethods
{
    public static class SearchExtensions
    {
        public static SearchResults Search(this string text, int page = 1, int pageSize = 10)
        {
            var searcher = ServiceLocator.Current.GetInstance<SearchHandler>();

            var freetExt = new FieldQuery(text);
            var onlyPges = new ContentQuery<SitePageData>();
            var readAccess = new AccessControlListQuery();
            readAccess.AddAclForUser(PrincipalInfo.Current, HttpContext.Current);

            var underStart = new VirtualPathQuery();
            underStart.AddContentNodes(ContentReference.StartPage);


            var query = new GroupQuery(LuceneOperator.AND);
            query.QueryExpressions.Add(freetExt);
            query.QueryExpressions.Add(onlyPges);
            query.QueryExpressions.Add(readAccess);
            query.QueryExpressions.Add(underStart);

            return searcher.GetSearchResults(query, page, pageSize);
        }
    }
}