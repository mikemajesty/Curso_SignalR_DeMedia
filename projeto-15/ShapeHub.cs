using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//---------------------------------//
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;
namespace projeto_15
{
    [HubName(hubName: "shapehub")]
    public class ShapeHub : Hub
    {
        
        public void UpdateModel(ShapeModel shapeModel)
        {
            Clients.AllExcept(Context.ConnectionId).updateShape(shapeModel);
        }

        public class ShapeModel
        {
            [JsonProperty("left")]
            public double Left { get; set; }
            [JsonProperty("top")]
            public double Top { get; set; }
            
        }
    }
}