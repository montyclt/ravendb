﻿using System.Threading.Tasks;
using Raven.Server.Documents.Sharding;
using Raven.Server.Routing;
using Raven.Server.Web.Studio.Sharding.Processors;

namespace Raven.Server.Web.Studio.Sharding
{
    public class ShardedStudioCollectionsHandler : ShardedRequestHandler
    {
        [RavenShardedAction("/databases/*/studio/collections/preview", "GET")]
        public async Task PreviewCollection()
        {
            using (var processor = new ShardedStudioCollectionsHandlerProcessorForPreviewCollection(this))
                await processor.ExecuteAsync();
        }
    }
}
