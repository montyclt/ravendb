﻿using System.Net.Http;
using Raven.NewClient.Client.Http;
using Sparrow.Json;

namespace Raven.NewClient.Client.Commands
{
    public class DeleteDatabaseCommand : RavenCommand<DeleteDatabaseResult>
    {
        public string Url;

        public override HttpRequestMessage CreateRequest(ServerNode node, out string url)
        {
            //TODO -EFRAT - WIP
            url = $"{node.Url}/admin/databases?name={node.Database}{Url}";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
            };
            
            return request;
        }

        public override void SetResponse(BlittableJsonReaderObject response)
        {
            if (response == null)
            {
                Result = null;
                return;
            }
            return;
        }
    }
}