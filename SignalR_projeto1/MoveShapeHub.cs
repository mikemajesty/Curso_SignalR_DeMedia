using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR_projeto1
{
    public class MoveShapeHub : Hub
    {
        public void UpdateModel(ShapeModel clienteModel)
        {

            clienteModel.LastUpdateBy = Context.ConnectionId;
            Clients.AllExcept(clienteModel.LastUpdateBy).updateShape(clienteModel);
        }
        public class ShapeModel
        {

            [JsonProperty(propertyName:"left")]
            public double Left { get; set; }
            [JsonProperty(propertyName:"top")]
            public double Top { get; set; }
            [JsonIgnore]
            public string LastUpdateBy { get; set; }
        }
    }
}