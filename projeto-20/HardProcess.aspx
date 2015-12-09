<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HardProcess.aspx.cs" Inherits="projeto_20.HardProcess" %>


<%@ Import Namespace="System.Diagnostics" %>
<%@ Import Namespace="System.Threading" %>
<%@ Import Namespace="System.Diagnostics" %>
<%@ Import Namespace="Microsoft.AspNet.SignalR" %>

<%
    Response.Expires = 1;
    var connectionID = Request["connID"];
    var hub = GlobalHost.ConnectionManager.GetHubContext<projeto_20.ProgressBarHub>();
    Stopwatch stopWatch = Stopwatch.StartNew();

    for (int i = 0; i < 100; i++)
    {
        hub.Clients.Client(connectionID).update(i);
        Thread.Sleep(150);
    }


%>
  <p>
      Hello World!!!
  </p>
  <p>
      Total time to show this message is <%:stopWatch.ElapsedMilliseconds / 1000 %> seconds.
  </p>